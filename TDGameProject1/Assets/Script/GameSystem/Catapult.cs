using UnityEngine;
using System.Collections;
public enum CastType {
						MidTyp,
						RandomType,
						TableType,
					 }

public class Catapult {
	public void Cast(GameObject parent, GameObject bulletprefab, Bullet bulletstate, CastType type){
		GameObject bullettemp = null;

		if (type == CastType.MidTyp) {
			bullettemp = NGUITools.AddChild(parent, bulletprefab);


		} else if (type == CastType.RandomType) {
			Vector3 RandomPoint = new Vector3(Random.Range(-200,200), Random.Range(-300,300), 0);
			bullettemp = NGUITools.AddChild(parent, bulletprefab);
			bullettemp.transform.localPosition += RandomPoint;
			
		}else if(type == CastType.TableType){
			bullettemp = NGUITools.AddChild(parent, bulletprefab);
			bullettemp.transform.localPosition = bulletstate.BornPoint;
		}
		BulletButton _BulletButton = bullettemp.GetComponent<BulletButton> ();
		_BulletButton.Init (bulletstate);
	}
}

public class Bullet {
	public float DurationTime = 5.0f;
	public GameObject CheckPoint = null;
	public Vector3 BornPoint = Vector3.zero;
	public Vector3 StartPoint = Vector3.zero;
	public Vector3 TargetPoint = Vector3.zero;
	public Vector3 TargetSize = Vector3.one;
	public Vector3 StartSize = Vector3.one;

}