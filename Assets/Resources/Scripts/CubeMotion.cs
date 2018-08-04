using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMotion : MonoBehaviour {

	Vector3 rotatePoint = Vector3.zero;
	Vector3 rotateAxis = Vector3.zero;
	float cubeAngle = 0f;

	Ray ray;
	RaycastHit hit;
	Vector3 pos;

	float cubeSizeHalf;
	bool isRotate = false;

	const int left = 0;
	const int right = 1;
	const int front = 2;
	const int back = 3;

	// Use this for initialization
	void Start () {
		cubeSizeHalf = transform.localScale.x / 2;
	}

	public void MoveCube(int direction){
		if (isRotate == false) {



			switch (direction) {
			case left:
				rotatePoint = transform.position + new Vector3 (-cubeSizeHalf, -cubeSizeHalf, 0f);
				rotateAxis = new Vector3 (0, 0, 1);
				break;
			case right:
				rotatePoint = transform.position + new Vector3 (cubeSizeHalf, -cubeSizeHalf, 0f);
				rotateAxis = new Vector3 (0, 0, -1);
				break;
			case front:
				rotatePoint = transform.position + new Vector3 (0f, -cubeSizeHalf, cubeSizeHalf);
				rotateAxis = new Vector3 (1, 0, 0);
				break;
			case back:
				rotatePoint = transform.position + new Vector3 (0f, -cubeSizeHalf, -cubeSizeHalf);
				rotateAxis = new Vector3 (-1, 0, 0);
				break;
			}

			pos = transform.position;

			Debug.Log (pos.x);
			Debug.Log (pos.y);
			Debug.Log (pos.z);

			Debug.Log (pos + rotateAxis * (float)0.5);

			ray = new Ray(pos + Quaternion.Euler( 0, -90, 0)*rotateAxis*(float)0.5 , Quaternion.Euler( 0, -90, 0) * rotateAxis);

			if (Physics.Raycast (ray, out hit, (float)0.5)) {
				Debug.Log ("wall!");
			} else {
				StartCoroutine (RotateCube ());
			}

		}
	}


	IEnumerator RotateCube(){
		
		isRotate = true;

		float sumAngle = 0f;
		while (sumAngle < 90f) {
			cubeAngle = 5f;
			sumAngle += cubeAngle;

			if (sumAngle > 90f) {
				cubeAngle -= sumAngle - 90f; 
			}
			transform.RotateAround (rotatePoint, rotateAxis, cubeAngle);

			yield return null;
		}

		isRotate = false;
		rotatePoint = Vector3.zero;
		rotateAxis = Vector3.zero;

		pos = transform.position;
		ray = new Ray(new Vector3(pos.x,pos.y-(float)0.5,pos.z), new Vector3(0,-1,0));

		if(Physics.Raycast(ray, out hit, (float)0.5)){
			hit.collider.GetComponent<Gimmick>().Motions ();
		}
		yield break;
	}
}