//========================================================================================================================
// Advanced Pooling System - Copyright © 2014 Sumit Das (SwiftFinger Games)
//
// Please direct any bugs/comments/suggestions to swiftfingergames@gmail.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to use
// or modify "Advanced Pooling System" in any and all games, subject to the
// following conditions:
//
// 1. The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// 2. Any product developed using "Advanced Pooling System" requires clearly
// readable "Advanced Pooling System" logo on splash screen or credits screen.
//
// 3. It is expressly forbid to sell or commercially distribute
// "Advanced Pooling System" outside of your games. You can freely use it in
// your games but you cannot commercially distribute the source code either
// directly or compiled into a library outside of your game.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//========================================================================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("AdvancedPoolingSystem/PoolingSystem")]

/// <summary>
/// <para>Version: 1.0.1</para>	 
/// <para>Author: Sumit Das (http://swiftfingergames.blogspot.com)</para>
/// <para>Support: swiftfingergames@gmail.com </para>
/// </summary>
public sealed class PoolingSystem : MonoBehaviour {
	
	[System.Serializable]
	public class PoolingItems
	{
		public GameObject prefab;
		public int amount;
	}

	public static PoolingSystem Instance;

	/// <summary>
	/// These fields will hold all the different types of assets you wish to pool.
	/// </summary>
	public PoolingItems[] poolingItems;
	public List<GameObject>[] pooledItems;

	/// <summary>
	/// The default pooling amount for each object type, in case the pooling amount is not mentioned or is 0.
	/// </summary>
	public int defaultPoolAmount = 10;

	/// <summary>
	/// Do you want the pool to expand in case more instances of pooled objects are required.
	/// </summary>
	public bool poolExpand = true;

	void Awake ()
	{
		Instance = this;
	}

	void Start () 
	{
		pooledItems = new List<GameObject>[poolingItems.Length];

		for(int i=0; i<poolingItems.Length; i++)
		{
			pooledItems[i] = new List<GameObject>();

			int poolingAmount;
			if(poolingItems[i].amount > 0) poolingAmount = poolingItems[i].amount;
			else poolingAmount = defaultPoolAmount;

			for(int j=0; j<poolingAmount; j++)
			{
				GameObject newItem = (GameObject) Instantiate(poolingItems[i].prefab);
				newItem.SetActive(false);
				pooledItems[i].Add(newItem);
				newItem.transform.parent = transform;
			}
		}
	}

	public static void DestroyAPS(GameObject myObject)
	{
		myObject.SetActive(false);
	}

	public GameObject InstantiateAPS (string itemType)
	{
		GameObject newObject = GetPooledItem(itemType);
		newObject.SetActive(true);
		return newObject;
	}

	public GameObject InstantiateAPS (string itemType, Vector3 itemPosition, Quaternion itemRotation)
	{
		GameObject newObject = GetPooledItem(itemType);
		newObject.transform.position = itemPosition;
		newObject.transform.rotation = itemRotation;
		newObject.SetActive(true);
		return newObject;
	}

	public GameObject InstantiateAPS (string itemType, Vector3 itemPosition, Quaternion itemRotation, GameObject myParent)
	{
		if(GetPooledItem(itemType) != null){
			GameObject newObject = GetPooledItem(itemType);
			newObject.transform.position = itemPosition;
			newObject.transform.rotation = itemRotation;
			newObject.transform.parent = myParent.transform;
			newObject.SetActive(true);
			return newObject;
		}
		return null;
	}

	public static void PlayEffect(GameObject particleEffect, int particlesAmount)
	{
		if(particleEffect.particleSystem)
		{
			particleEffect.particleSystem.Emit(particlesAmount);
		}
	}

	public static void PlaySound(GameObject soundSource)
	{
		if(soundSource.audio)
		{
			soundSource.audio.PlayOneShot(soundSource.audio.GetComponent<AudioSource>().clip);
		}
	}

	public GameObject GetPooledItem (string itemType)
	{
		for(int i=0; i<poolingItems.Length; i++)
		{
			if(poolingItems[i].prefab.name == itemType)
			{
				for(int j=0; j<pooledItems[i].Count; j++)
				{
					if(!pooledItems[i][j].activeInHierarchy)
					{
						return pooledItems[i][j];
					}
				}
				
				if(poolExpand)
				{
					GameObject newItem = (GameObject) Instantiate(poolingItems[i].prefab);
					newItem.SetActive(false);
					pooledItems[i].Add(newItem);
					newItem.transform.parent = transform;
					return newItem;
				}
				
				break;
			}
		}
		
		return null;
	}

}

public static class PoolingSystemExtensions
{
	public static void DestroyAPS(this GameObject myobject)
	{
		PoolingSystem.DestroyAPS(myobject);
	}

	public static void PlayEffect(this GameObject particleEffect, int particlesAmount)
	{
		PoolingSystem.PlayEffect(particleEffect, particlesAmount);
	}

	public static void PlaySound(this GameObject soundSource)
	{
		PoolingSystem.PlaySound(soundSource);
	}
}
