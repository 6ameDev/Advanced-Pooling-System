using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	PoolingSystem pS;

	int[] count = new int[] {0,0,0,0};

	float sizeW, sizeH;
	bool expandable = true;

	public GUIText msg;
	Color colorT;

	void Start () {

		pS = PoolingSystem.Instance;

		sizeW = Screen.width / 72;
		sizeH = Screen.height / 128;

		colorT = msg.color;

	}
	
	void Update () {

		for(int i=0; i<pS.poolingItems.Length; i++)
		{
			count[i] = pS.pooledItems[i].Count;
		}

		count[3]=0;
		for(int j=0; j<pS.pooledItems[0].Count; j++)
		{
			if(pS.pooledItems[0][j].activeInHierarchy)
			{
				count[3]++;
			}
		}

		pS.poolExpand = expandable;

		if(colorT.a >= 0)
			colorT.a -= Time.deltaTime/2;

		msg.material.color = colorT;
	
	}

	void OnGUI()
	{
		GUIStyle defaultStyle = GUI.skin.GetStyle("Label");
		defaultStyle.alignment = TextAnchor.UpperLeft;

		GUI.Label (new Rect (sizeW*7,0,sizeW*50,50), "Alive Bullets: "+count[3], defaultStyle);
		GUI.Label (new Rect (sizeW*7,sizeH*5,sizeW*50,50), "Pooled Bullets: "+count[0], defaultStyle);
		GUI.Label (new Rect (sizeW*7,sizeH*10,sizeW*50,50), "Pooled ParticleSys: "+count[1], defaultStyle);
		GUI.Label (new Rect (sizeW*7,sizeH*15,sizeW*50,50), "Pooled SoundSrc: "+count[2], defaultStyle);

		expandable = GUI.Toggle(new Rect(sizeW*7,sizeH*20, sizeW*50, sizeH*6), expandable, "Expandable Pool");

		if (GUI.Button(new Rect(sizeW*7,sizeH*27,sizeW*29,sizeH*6), "RESET"))
			Application.LoadLevel("Demo");

		GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.MiddleCenter;

		//GUI.Label (new Rect (0,0,Screen.width,Screen.height), "Tap below to Fire", centeredStyle);
	}
}
