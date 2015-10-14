using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TimeClock  {
	static public TimeClock timeClock{
		get{ 
			if( _TimeClock != null )
				return _TimeClock;
			else{
				_TimeClock = new TimeClock();
				return _TimeClock;
			}
		}
	}

	static public EventDelegate et = null;
	static public TimeClock _TimeClock = null;


	Dictionary<string, TimeClockState > _ClockList = new Dictionary<string, TimeClockState>();

	public TimeClock()
	{

	}
	public void Clock(){
		foreach (KeyValuePair<string, TimeClockState > item in TimeClock.timeClock._ClockList) {
			if(item.Value.TimeClock()){
				item.Value.ReSetTime();
			}
		}
	}
	public bool AddTimeClock(string Name, float TimeForSecond, TimeClockState.OnClockCallBack callback){
		if( TimeClock._TimeClock._ClockList.ContainsKey(Name) )
			return false;
		else if( TimeForSecond <= 0 )
			return false;
		else if( callback == null )
			return false;
		else{
			TimeClock._TimeClock._ClockList.Add(Name, new TimeClockState(TimeForSecond, callback));
		}
		
		return true;
	}
	public bool RemoveTimeClock(string Name){
		if(!_TimeClock._ClockList.ContainsKey(Name) )
			return false;
		else{
			_TimeClock._ClockList.Remove(Name);
		}
		return true;
	}
	public bool Contants(string Name){
		if(_TimeClock._ClockList.ContainsKey(Name))
			return true;
		else
			return false;
	}
}
public class TimeClockState{
	float _RunTime = 0;
	float _EndTime = 0;
	public delegate void OnClockCallBack();
	public OnClockCallBack OnTime;

	public TimeClockState(float EndTime,OnClockCallBack callback ){
		_RunTime = _EndTime = EndTime;
		OnTime = callback;
	}
	public void RunCallBack(){
		if(OnTime != null)
			OnTime();
	}
	public bool TimeClock(){
		_RunTime += Time.deltaTime;

		if(_RunTime >= _EndTime){
			RunCallBack();
			return true;
		}
		return false;
	}
	public void ReSetTime(){
		_RunTime = 0;
	}
}