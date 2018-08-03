using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMotion : MonoBehaviour {

	Vector3 rotatePoint = Vector3.zero;
	Vector3 rotateAxis = Vector3.zero;
	float cubeAngle = 0f;

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

			StartCoroutine (RotateCube ());

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

		yield break;
	}

}
