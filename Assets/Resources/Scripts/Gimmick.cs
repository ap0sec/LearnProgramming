using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour {

	int type;
	GameObject cube;

	// Use this for initialization
	void Start () {
		type = 0;
		switch (transform.tag) {
		case "Goal":
			type = 1;
			break;
		}
		cube = GameObject.FindGameObjectWithTag("Player");
	}

	public void Motions () {
		switch (type) {
		case 1:
			GoalMotion ();
			break;
		}
	}

	void GoalMotion(){
		Debug.Log ("Goal");
	}

}
