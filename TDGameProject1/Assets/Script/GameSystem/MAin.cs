using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MAin : MonoBehaviour {
	public float speed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		Time.timeScale = speed;
		TimeClock.timeClock.Clock();
	}
	void add_targetList(target _target){
	}
}
