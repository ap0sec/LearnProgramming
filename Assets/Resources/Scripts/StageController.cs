using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

	const int Size = 9;
	MapData md = new MapData(Size);

	// Use this for initialization
	void Start () {
		MapLoader ();
		MapMaker ();
	}

	void MapLoader () {
		string json = Resources.Load<TextAsset>("MapData/" + SceneManager.GetActiveScene().name).ToString();
		JsonUtility.FromJsonOverwrite(json, md);
	}

	void MapMaker () {
		GameObject floor = (GameObject)Resources.Load ("Prefabs/Floor");
		GameObject wall = (GameObject)Resources.Load ("Prefabs/Wall");
		GameObject cube = (GameObject)Resources.Load ("prefabs/Cube");
		GameObject goal = (GameObject)Resources.Load ("prefabs/Goal");
		GameObject tmp;

		for (int i = 0; i < Size; i++) {
			for (int j = 0; j < Size; j++) {
				switch (md.z [i].x [j]) {
				case 0:
					Instantiate (floor, new Vector3 (j, 0, i), Quaternion.identity);
					break;
				case 1:
					Instantiate (wall, new Vector3 (j, 0, i), Quaternion.identity);
					break;
				case 2:
					Instantiate (floor, new Vector3 (j, 0, i), Quaternion.identity);

					GameObject player = Instantiate (cube, new Vector3 (j, (float)0.6, i), Quaternion.identity) as GameObject;
					player.name = "Cube";
					player.tag = "Player";

					break;
				case 3:
					tmp = Instantiate (goal, new Vector3 (j, 0, i), Quaternion.identity) as GameObject;
					tmp.name = "Goal";
					break;
				}
			}
		}
	}
}
