using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CheckType{
	Bad,
	Good,
	Nise,
}

public class GameManater : MonoBehaviour{
	public static GameManater _GameManater;
	public int _point = 0;
	public int Point{
		get{ return _point;}
		set{ 
			_point = value;
			if ( this.pointlabel !=null )
				this.pointlabel.text = _point.ToString();
		}
	}
	int count = 0;
	LevelData leveldata;

	public UILabel pointlabel = null;
	public GameObject BulletPanel = null;
	Catapult catapult = null;
	public List<GameObject> ButtonEndPoint = null; 
	public List<GameObject> CheckPoint = null; 
	public List<GameObject> live = null;


	public UIPanel FXpanel;
	public UIPanel UIpanel;
	public UIPanel BGpanel;
	public UIPanel Objpanel;


	void Awake() {
		GameSetting.DefaultSetting();
	}
	// Use this for initialization
	void Start () {
		_GameManater = this;
		catapult = new Catapult ();
		leveldata = new LevelData();
		AutoStartTableType ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			GameObject bulletprefab = Resources.Load("Prefab/target") as GameObject;

			Bullet bulletstate = new Bullet();
			bulletstate.StartSize = new Vector3(0.1f, 0.1f, 1.0f);
			int objindex = Random.Range(0,4);
			bulletstate.TargetPoint = ButtonEndPoint[objindex].transform.localPosition;
			bulletstate.CheckPoint = CheckPoint[objindex];
			catapult.Cast(BulletPanel, bulletprefab, bulletstate, CastType.MidTyp);
		}
		if (Input.GetKeyDown (KeyCode.F2)) {
			GameObject bulletprefab = Resources.Load("Prefab/target") as GameObject;
			
			Bullet bulletstate = new Bullet();
			bulletstate.StartSize = new Vector3(0.1f, 0.1f, 1.0f);
			catapult.Cast(BulletPanel, bulletprefab, bulletstate, CastType.RandomType);
		}
	}

	public void AutoStart(){
		Invoke ("AutoStart", 0.5f);
		GameObject bulletprefab = Resources.Load("Prefab/target") as GameObject;
		
		Bullet bulletstate = new Bullet();
		bulletstate.StartSize = new Vector3(0.1f, 0.1f, 1.0f);
		int objindex = Random.Range(0,4);
		bulletstate.TargetPoint = ButtonEndPoint[objindex].transform.localPosition;
		bulletstate.CheckPoint = CheckPoint[objindex];
		catapult.Cast(BulletPanel, bulletprefab, bulletstate, CastType.MidTyp);
	}
	public void AutoStartTableType(){
		GameObject bulletprefab = Resources.Load("Prefab/target") as GameObject;
		Bullet bulletstate = new Bullet();
		bulletstate.StartPoint = (Vector3)leveldata.StartPoint[count];
		bulletstate.DurationTime = leveldata.DurationTime[count];
		bulletstate.TargetPoint = leveldata.EndPoint[count];
		//bulletstate.StartSize = new Vector3(0.1f, 0.1f, 1.0f);
		catapult.Cast(BulletPanel, bulletprefab, bulletstate, CastType.TableType);
		count++;
		if(count < leveldata.StartPoint.Count)
			Invoke ("AutoStartTableType", 0.5f);
		else
			Invoke ("LevelEnd", 5f);
	}

	public void LevelEnd(){

	}

	public void initlive(){
		foreach (GameObject item in live) {
			CollisionCallback _CollisionCallback = item.GetComponent<CollisionCallback>();
			_CollisionCallback.CollisionEnter = killself;
		}
	}

	public void killself(Collision _Collision){
		Destroy(_Collision.gameObject);
	}
}

public static class ManagerFunction{
	public static void AddPoint( int point ){
		GameManater._GameManater.Point += point;
	}

}

public class LevelData{
	public List<int> DurationTime = new List<int>(){3,
		4,
		3,
		3,
		2,
		4,
		3,
		2,
		2,
		3,
		4,
		3,
		2,
		3,
		2,
		4,
		2,
		4,
		3,
		3,
		2,
		3,
		3,
		2,
		4,
		3,
		3,
		2,
		2,
		2,
		2,
		3,
		2,
		3,
		2,
		3,
		2,
		2,
		4,
		4,
		2,
		4,
		3,
		4,
		4,
		3,
		3,
		4,
		3,
		2};
	public List<Vector2> StartPoint = new List<Vector2>(){new Vector2(-124,731),
		new Vector2(-80,826),
		new Vector2(155,816),
		new Vector2(400,879),
		new Vector2(330,700),
		new Vector2(-329,621),
		new Vector2(121,733),
		new Vector2(134,627),
		new Vector2(327,862),
		new Vector2(-217,686),
		new Vector2(-94,809),
		new Vector2(-26,879),
		new Vector2(49,747),
		new Vector2(-217,740),
		new Vector2(71,897),
		new Vector2(72,616),
		new Vector2(-128,890),
		new Vector2(330,642),
		new Vector2(-136,616),
		new Vector2(48,876),
		new Vector2(-245,686),
		new Vector2(405,728),
		new Vector2(232,611),
		new Vector2(-247,843),
		new Vector2(73,859),
		new Vector2(-100,707),
		new Vector2(361,879),
		new Vector2(-375,753),
		new Vector2(294,717),
		new Vector2(91,807),
		new Vector2(48,894),
		new Vector2(118,691),
		new Vector2(373,732),
		new Vector2(286,822),
		new Vector2(365,710),
		new Vector2(-432,756),
		new Vector2(66,684),
		new Vector2(-190,609),
		new Vector2(146,793),
		new Vector2(-157,866),
		new Vector2(61,711),
		new Vector2(98,753),
		new Vector2(42,669),
		new Vector2(-58,627),
		new Vector2(446,900),
		new Vector2(289,783),
		new Vector2(-159,681),
		new Vector2(-309,867),
		new Vector2(120,661),
		new Vector2(-317,769)};	

	public List<Vector2> EndPoint = new List<Vector2>(){new Vector2(-9,-450),
		new Vector2(-24,-450),
		new Vector2(-195,-450),
		new Vector2(99,-450),
		new Vector2(-152,-450),
		new Vector2(94,-450),
		new Vector2(198,-450),
		new Vector2(148,-450),
		new Vector2(229,-450),
		new Vector2(23,-450),
		new Vector2(-284,-450),
		new Vector2(-158,-450),
		new Vector2(-104,-450),
		new Vector2(128,-450),
		new Vector2(-259,-450),
		new Vector2(356,-450),
		new Vector2(77,-450),
		new Vector2(101,-450),
		new Vector2(249,-450),
		new Vector2(-71,-450),
		new Vector2(-357,-450),
		new Vector2(235,-450),
		new Vector2(-300,-450),
		new Vector2(-219,-450),
		new Vector2(59,-450),
		new Vector2(97,-450),
		new Vector2(248,-450),
		new Vector2(-293,-450),
		new Vector2(54,-450),
		new Vector2(-123,-450),
		new Vector2(96,-450),
		new Vector2(-67,-450),
		new Vector2(227,-450),
		new Vector2(-12,-450),
		new Vector2(-132,-450),
		new Vector2(226,-450),
		new Vector2(282,-450),
		new Vector2(76,-450),
		new Vector2(-360,-450),
		new Vector2(-353,-450),
		new Vector2(81,-450),
		new Vector2(-168,-450),
		new Vector2(-293,-450),
		new Vector2(318,-450),
		new Vector2(156,-450),
		new Vector2(192,-450),
		new Vector2(-50,-450),
		new Vector2(243,-450),
		new Vector2(278,-450),
		new Vector2(137,-450)};
}
