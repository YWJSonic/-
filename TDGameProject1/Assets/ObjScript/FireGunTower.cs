using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireGunTower : MonoBehaviour {
	public string ID = "qqqwer";
	
	List<target> Target = new List<target>();
	Tower tower = new Tower();
	CollisionCallback collision2D;
	
	public bool isAttack = false;
	// Use this for initialization
	void Start () {
		collision2D = gameObject.GetComponent<CollisionCallback>();
		tower.atkSpeed = 0.2f;
		collision2D.TriggerEnter2D = getTarget;
		
		collision2D.TriggerExit2D = lostTarget;
	}
	void getTarget(Collider2D target){
		Target.Add(target.gameObject.GetComponent<target>());
		if(Target.Count > 0)
			Attack();
	}
	void lostTarget(Collider2D target){
		target tag = target.gameObject.GetComponent<target>();
		if(Target.Contains(tag))
			Target.Remove(tag);

		if(Target.Count <= 0)
			StopAttack();
	}
	void lostTarget(){
		
		Target.RemoveAt(0);
		if(Target.Count <= 0)
			StopAttack();
	}
	void StopAttack(){
		if(TimeClock.timeClock.Contants( ID )){
			TimeClock.timeClock.RemoveTimeClock( ID );
		}
	}
	void Attack(){
		if(!TimeClock.timeClock.Contants( ID )){
			TimeClock.timeClock.AddTimeClock(ID, tower.atkSpeed, cooldownEnd);
		}
		if(Target[0].HP > 0)
			Target[0].HP -= (int)tower.atk;
		else
			lostTarget();
	}
	void cooldownEnd(){
		Attack();
	}
}