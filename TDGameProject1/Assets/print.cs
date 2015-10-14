using UnityEngine;
using System.Collections;

public class print : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.down * Time.deltaTime * 0.1f, Space.Self);
	}
}
