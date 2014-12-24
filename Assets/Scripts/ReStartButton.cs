using UnityEngine;
using System.Collections;

public class ReStartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (100, 100, 100, 100), "ReStart")) {
			Debug.Log ("ReStart");
			Application.LoadLevel ("OnGame");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
