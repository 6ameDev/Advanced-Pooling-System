using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	private PoolingSystem poolingSystem;
	public GameObject leftGun, rightGun;
	private Transform leftGunT, rightGunT;
	private GameObject fireEffectL, fireEffectR;
	private GameObject shootSoundL, shootSoundR;

	public float fireDelay = 0.5f;
	float timeToNextFire = 0;

	void Update() 
	{
		if(Input.GetMouseButton(0))
		{
			if(Input.mousePosition.y < Screen.height/2)
			{
				Fire ();
			}
		}
		MoveShip();
	}

	void Start()
	{
		poolingSystem = PoolingSystem.Instance;

		leftGunT = leftGun.transform;
		rightGunT = rightGun.transform;

		fireEffectL =  poolingSystem.InstantiateAPS("ShootEffect", leftGunT.position, leftGunT.rotation, leftGun);
		fireEffectR =  poolingSystem.InstantiateAPS("ShootEffect", rightGunT.position, rightGunT.rotation, rightGun);

		shootSoundL =  poolingSystem.InstantiateAPS("ShootSound", leftGunT.position, leftGunT.rotation, Camera.main.camera.gameObject);
		shootSoundR =  poolingSystem.InstantiateAPS("ShootSound", rightGunT.position, rightGunT.rotation, Camera.main.camera.gameObject);

	}

	void Fire()
	{
		if(Time.time > timeToNextFire)
		{
			timeToNextFire = Time.time + fireDelay;

			GameObject bulletL, bulletR;

			bulletL = poolingSystem.InstantiateAPS("Bullet", leftGunT.position, leftGunT.rotation);
			bulletR = poolingSystem.InstantiateAPS("Bullet", rightGunT.position, rightGunT.rotation);

			if(bulletL == null || bulletR == null)
				return;

			fireEffectL.PlayEffect(30);
			fireEffectR.PlayEffect(30);

			shootSoundL.PlaySound();
			shootSoundR.PlaySound();
		}
	}

	void MoveShip()
	{
		if(Input.GetButtonDown("Horizontal"))
		{
			float speed;

			if(Input.GetAxis("Horizontal") > 0)
				speed = 4;
			else
				speed = -4;

			transform.rigidbody.velocity = (new Vector3(speed,0,0));
		}
	}
}
