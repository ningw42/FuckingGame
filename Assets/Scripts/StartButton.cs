using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnGUI(){
        if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.4f, 100, 30), "Start"))
        {
			Application.LoadLevel ("OnGame");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
