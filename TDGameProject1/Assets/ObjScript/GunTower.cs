using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunTower : MonoBehaviour {
	public string ID = "qqqwer";

	List<int> attackindex = new List<int>();
	List<target> Target = new List<target>();
	Tower tower = new Tower();
	CollisionCallback collision2D;

	void Start () {
		tower.atk = 5;
		tower.atkSpeed = 1;
		collision2D = gameObject.GetComponent<CollisionCallback>();
		collision2D.TriggerEnter2D = getTarget;
		collision2D.TriggerExit2D = lostTarget;
	}

	void getTarget(Collider2D target){
		Target.Add(target.gameObject.GetComponent<target>());

		if(Target.Count > 0 && !TimeClock.timeClock.Contants( ID ))
			TimeClock.timeClock.AddTimeClock(ID, tower.atkSpeed, cooldownEnd);

	}
	void lostTarget(Collider2D target){
		target tag = target.gameObject.GetComponent<target>();
		if(Target.Contains(tag))
			Target.Remove(tag);

		if(Target.Count <= 0)
			StopAttack();
	}
	void lostTarget(target _target){
		if(Target.Contains(_target))
			Target.Remove(_target);
		
		if(Target.Count <= 0)
			StopAttack();
	}
	void lostTarget(){
		Target.RemoveAt(0);
		if(Target.Count <= 0)
			StopAttack();
	}

	void Attack(){
		if(Target[0].HP > 0){
			if(!Target[0].isDaed)
				Target[0].HP -= (int)tower.atk;
		}else{
			lostTarget();
		}
	}
	void StopAttack(){
		if(TimeClock.timeClock.Contants( ID )){
			TimeClock.timeClock.RemoveTimeClock( ID );
		}
	}
	void cooldownEnd(){
		MultiAttack();
	}

	void MultiAttack(){
		for (int i = 0; i < Target.Count; i++) {
			if(attackindex.Count > 5)
				continue;
			if(Target[i].HP > 0)
				attackindex.Add(i);
			else
				lostTarget(Target[i]);
		}
		for (int i = attackindex.Count - 1; i >= 0; i--) {
			if(!Target[i].isDaed)
				Target[i].HP -= (int)tower.atk;
		}
		attackindex.Clear();
	}
	void LinkAttack(){

	}
	void ReflectionAttack(){

	}
	void PenetrateAttack(){

	}
}
