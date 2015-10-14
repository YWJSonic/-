using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
	public GameObject GamePanel;
	public List<GameObject> ObkjList = null;

	// Use this for initialization
	void Start () {
		ObkjList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F1)){
			GameObject Objtemp = Resources.Load("Prefab/target") as GameObject;
			Vector3 newpoint = Getpoint();
			if ( newpoint != Vector3.zero ){
				Objtemp = NGUITools.AddChild(GamePanel, Objtemp);
				Objtemp.transform.localPosition = newpoint;
				ObkjList.Add(Objtemp);
			}
		}
	}

	Vector3 Getpoint(){
		Vector3 temp = Vector3.zero;
		bool pointcover = true;
		int whilecount = 50;
		List<GameObject> templist = new List<GameObject>(ObkjList);

		while( pointcover && whilecount > 0){
			pointcover = false;
			temp = new Vector3(Random.Range(-300, 300), Random.Range(-400, 400), 0.0f);

			for (int i = 0; i < templist.Count; i++) {
				float Distance = Vector3.Distance(templist[i].transform.localPosition, temp);
				if ( Distance < 127.0f )
					pointcover = true;
			}
			whilecount --;
		}
		if( pointcover){
			return Vector3.zero;
		}else{
			return temp;
		}
	}
}
