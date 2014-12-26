using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
    public GUISkin skin;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnGUI(){
        if (GUI.Button(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.4f, 200, 60), "Start", skin.button))
        {
			Application.LoadLevel ("OnGame");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
