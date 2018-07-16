using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

	const int Size = 9;
	MapData md = new MapData(Size);

	// Use this for initialization
	void Start () {
		MapLoader();
		MapMaker ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MapLoader () {
		string json = Resources.Load<TextAsset>("MapData/tutorial").ToString();
		JsonUtility.FromJsonOverwrite(json, md);

		/*
		System.Random r = new System.Random();
		for(int i = 0; i < Size; i++){
			for(int j = 0; j < Size; j++){
				md.x[i].y[j] = r.Next(0,2);
			}
		}
		string json = JsonUtility.ToJson(md);
		Debug.Log (json);
		File.WriteAllText(Application.dataPath + "/Resources/tutorial.json", json);
		*/
	}

	void MapMaker () {
		GameObject floor = (GameObject)Resources.Load ("Prefabs/Floor");
		GameObject wall = (GameObject)Resources.Load ("Prefabs/Wall");
		GameObject cube = (GameObject)Resources.Load ("prefabs/Cube");

		for (int i = 0; i < Size; i++) {
			for (int j = 0; j < Size; j++) {
				switch (md.z[i].x[j]) {
				case 0:
					Instantiate (floor, new Vector3 (j, 0, i), Quaternion.identity);
					break;
				case 1:
					Instantiate (wall, new Vector3 (j, 0, i), Quaternion.identity);
					break;
				case 2:
					Instantiate (floor, new Vector3 (j, 0, i), Quaternion.identity);
					GameObject player = Instantiate (cube, new Vector3 (j, (float)0.5, i), Quaternion.identity) as GameObject;
					player.name = "player";
					break;
				}
			}
		}
	}
}
