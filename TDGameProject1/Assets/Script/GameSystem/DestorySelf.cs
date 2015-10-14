using UnityEngine;
using System.Collections;

public class DestorySelf : MonoBehaviour {
	[SerializeField]
	private float time = 0.0f;
	// Use this for initialization
	void Start () {
		Invoke("Killself", time);
	}

	void Killself(){
		Destroy(gameObject, time);
	}
}
