using UnityEngine;
using System.Collections;

public class DieTimer : MonoBehaviour {

	public float dieTime = 0.25f;
	private float bornTime;
	
	void OnEnable () {
		
		bornTime = Time.time;
	}
	
	void Update () {
		
		DestroyMe();
	}
	
	private void DestroyMe()
	{
		if(Time.time - bornTime > dieTime)
			gameObject.SetActive(false);
	}
}
