using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapData {
	public State[] z;

	public MapData(int size){
		z = new State[size];
		for(int i = 0; i < size; i++){
			z [i] = new State (size);
		}
	}
}

[Serializable]
public class State{
	public int[] x;

	public State(int size){
		x = new int[size];
	}
}