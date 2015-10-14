using UnityEngine;
using System.Collections;

public class Tower{
	public enum attacktype { One, Mtlti, Link, Reflection, Penetrate}

	float _hp = 1;
	float _def = 1;
	float _atk = 1;
	float _atkspeed = 1;
	float _atkrange = 1;
	float _bulletflyspeed = 1;
	attacktype _attacktype = attacktype.One;
	int _cost = 1;
	int _sell = 1;
	int _skill = 1;


	GameObject Bullet;

	public float hp{
		get{return _hp;}
	}
	public float def{
		get{return _def;}
	}
	public float atk{
		get{return _atk;}
		set{ _atk = value; }
	}
	public float atkSpeed{
		get{return _atkspeed;}
		set{ _atkspeed = value;}
	}
	public float atkRange{
		get{return _atkrange;}
	}
	public float bulletFlySpeed{
		get{return _bulletflyspeed;}
	}
	public attacktype attackType{
		get{return _attacktype;}
	}
	public int cost{
		get{return _cost;}
	}
	public int sell{
		get{return _sell;}
	}
	public int skill{
		get{return _skill;}
	}
}
