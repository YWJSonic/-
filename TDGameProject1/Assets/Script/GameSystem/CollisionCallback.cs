using UnityEngine;
using System.Collections;

public class CollisionCallback : MonoBehaviour {
	public delegate void OnCollisionCallback(Collision coll);
	public delegate void OnTriggerCallback(Collider coll);
	public delegate void OnCollisionCallback2D(Collision2D coll);
	public delegate void OnTriggerCallback2D(Collider2D coll);

	public OnCollisionCallback CollisionEnter;
	public OnCollisionCallback CollisionExit;
	public OnCollisionCallback CollisionStay;
	public OnTriggerCallback TriggerEnter;
	public OnTriggerCallback TriggerExit;
	public OnTriggerCallback TriggerStay;
	
	public OnCollisionCallback2D CollisionEnter2D;
	public OnCollisionCallback2D CollisionExit2D;
	public OnCollisionCallback2D CollisionStay2D;
	public OnTriggerCallback2D TriggerEnter2D;
	public OnTriggerCallback2D TriggerExit2D;
	public OnTriggerCallback2D TriggerStay2D;

	//////3D
	void OnCollisionEnter(Collision coll) {
		Debug.Log("OnCollisionEnter: " + coll.gameObject.name);
		if( CollisionEnter != null)
			CollisionEnter( coll );
	}
	void OnCollisionExit(Collision coll) {
		Debug.Log("OnCollisionExit: " + coll.gameObject.name);
		if( CollisionExit != null)
			CollisionExit( coll );
	}
	void OnCollisionStay(Collision coll) {
		Debug.Log("OnCollisionStay: " + coll.gameObject.name);
		if( CollisionStay != null)
			CollisionStay( coll );
	}

	void OnTriggerEnter(Collider coll) {
		Debug.Log("OnTriggerEnter: " + coll.gameObject.name);
		if( TriggerEnter != null)
			TriggerEnter( coll );
	}
	void OnTriggerExit(Collider coll) {
		Debug.Log("OnTriggerExit: " + coll.gameObject.name);
		if( TriggerExit != null)
			TriggerExit( coll );
	}
	void OnTriggerStay(Collider coll) {
		Debug.Log("OnTriggerStay: " + coll.gameObject.name);
		if( TriggerStay != null)
			TriggerStay( coll );
	}
	///////////2D
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("OnCollisionEnter2D: " + coll.gameObject.name);
		if( CollisionEnter2D != null)
			CollisionEnter2D( coll );
	}
	void OnCollisionExit2D(Collision2D coll) {
		Debug.Log("OnCollisionExit2D: " + coll.gameObject.name);
		if( CollisionExit2D != null)
			CollisionExit2D( coll );
	}
	void OnCollisionStay2D(Collision2D coll) {
		Debug.Log("OnCollisionStay2D: " + coll.gameObject.name);
		if( CollisionStay2D != null)
			CollisionStay2D( coll );
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("OnTriggerEnter2D: " + coll.gameObject.name);
		if( TriggerEnter2D != null)
			TriggerEnter2D( coll );
	}
	void OnTriggerExit2D(Collider2D coll) {
		Debug.Log("OnTriggerExit2D: " + coll.gameObject.name);
		if( TriggerExit2D != null)
			TriggerExit2D( coll );
	}
	void OnTriggerStay2D(Collider2D coll) {
		Debug.Log("OnTriggerStay2D :" + coll.gameObject.name);
		if( TriggerStay2D != null)
			TriggerStay2D( coll );
	}
}
