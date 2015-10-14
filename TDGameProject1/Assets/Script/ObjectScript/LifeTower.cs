using UnityEngine;
using System.Collections;

public class LifeTower : MonoBehaviour {
	CollisionCallback _CollisionCallback;
	// Use this for initialization
	void Start () {
		_CollisionCallback = gameObject.GetComponent<CollisionCallback>();
		_CollisionCallback.TriggerEnter = OnHit;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHit(Collider collider){
		gameObject.SetActive(false);
	}
}
