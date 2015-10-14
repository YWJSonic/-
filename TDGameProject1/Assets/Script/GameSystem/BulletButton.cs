using UnityEngine;
using System.Collections;

public class BulletButton : MonoBehaviour {
	
	public Bullet State = null;
	public UILabel distancelabel = null;
	public UISprite sprite = null;

	Collider _Colldier = null;
	CollisionCallback _CollisionCallback;
	TweenPosition TweenPost;
	TweenScale TweenScal;
	TweenRotation TweenRota;
	
	int RatationCount = 0;
	public GameObject ActionTarget;
	// Use this for initialization
	void Start () {
		_Colldier = sprite.gameObject.GetComponent<Collider>();
		_CollisionCallback = sprite.gameObject.GetComponent<CollisionCallback>();
		_CollisionCallback.CollisionEnter = OnHit;
	}

	void Update(){
		if (distancelabel != null && !distancelabel.enabled) {
			float distance = Vector2.Distance (State.CheckPoint.transform.localPosition, gameObject.transform.localPosition); 
			distancelabel.text = distance.ToString ();
		}
	}

	public void Init(Bullet bullet){
		State = bullet;
		TweenPost = ActionTarget.AddComponent<TweenPosition> ();
		TweenPost.duration = bullet.DurationTime;
		TweenPost.from = bullet.StartPoint;
		TweenPost.to = bullet.TargetPoint;
		EventDelegate.Add( TweenPost.onFinished, DeleteSelf);

		if(bullet.StartSize != Vector3.one){
			TweenScal = ActionTarget.AddComponent<TweenScale> ();
			TweenScal.duration = bullet.DurationTime;
			TweenScal.from = bullet.StartSize;
			TweenScal.to = bullet.TargetSize;

			TweenScal.Play (true);
		}


		TweenRota = ActionTarget.AddComponent<TweenRotation>();
		TweenRota.to = new Vector3(0.0f, 0.0f, 360.0f);
		TweenRota.duration = bullet.DurationTime;
		TweenRota.style = UITweener.Style.Once;
		EventDelegate.Add(TweenRota.onFinished, _RotationCount);



		TweenPost.Play (true);
		TweenRota.Play (true);
		//Invoke ("DeleteSelf", bullet.DurationTime + 1.0f);
	}

	public void OnClick(){
		ManagerFunction.AddPoint(1);

		DeleteSelf();
	}

	void DeleteSelf(){
		GameObject fx = NGUITools.AddChild( GameManater._GameManater.FXpanel.gameObject, Resources.Load("FX/boom") as GameObject );
		fx.transform.localPosition = ActionTarget.transform.localPosition;
		DestroyImmediate (gameObject);
	}

	void _RotationCount(){
		RatationCount+=1;
		if (RatationCount >= 2){
			return;
		}
		TweenRota.Play(true);
		
	}
	public void OnHit(Collision collidision){
		Debug.Log("Collider collider");
	}
}
