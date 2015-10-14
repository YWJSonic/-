using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class target : MonoBehaviour {
	public int _HP = 100;
	public float _MaxHP = 100;
	public bool isDaed = false;
	public UISlider slider;
	TweenRotation Tweenrota;
	TweenScale Tweenscal;

	public GameObject spriteObj;

	int RatationCount = 0;

	public int HP {
		get{return _HP;}
		set{ 
			_HP = value;
			SetSlider();
			if (_HP <= 0){
				isDaed = true;
				gameObject.SetActive(false);
				deleteself();
			}
		}
	}
	void Start(){
		Tweenrota = spriteObj.AddComponent<TweenRotation>();
		Tweenscal = spriteObj.AddComponent<TweenScale>();

		Tweenrota.to = new Vector3(0.0f, 0.0f, 360.0f);
		Tweenrota.duration = 2.0f;
		Tweenrota.style = UITweener.Style.Once;
		EventDelegate.Add(Tweenrota.onFinished, _RotationCount);

		Tweenscal.from = new Vector3(0.1f, 0.1f, 1.0f);
		Tweenscal.to = new Vector3(1.0f, 1.0f, 1.0f);
		Tweenscal.duration = 2.0f;
		EventDelegate.Add( Tweenscal.onFinished, deleteself);
	}
	void _RotationCount(){
		RatationCount+=1;
		if (RatationCount >= 2){
			return;
		}
		Tweenrota.Play(true);

	}

	void SetSlider(){
		slider.value = (float)_HP / _MaxHP;
	}
	void deleteself(){
		Destroy(gameObject);
	}
	public void OnClick(){
		HP -= 1;

	}
}
