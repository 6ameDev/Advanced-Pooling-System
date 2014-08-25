using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed = 3;
	public float dieTime = 2;
	private float bornTime;

	void OnEnable () 
	{
		bornTime = Time.time;
	}
	
	void Update () 
	{
		DestroyBullet();
		MoveBullet();
	}

	private void DestroyBullet()
	{
		if(Time.time - bornTime > dieTime)
			gameObject.DestroyAPS();
	}

	private void MoveBullet()
	{
		transform.rigidbody.velocity = new Vector3(0,0,speed);
	}
}
