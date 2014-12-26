using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
    public Player player;
	// Use this for initialization
	void Start () {
        Instantiate(player, new Vector3(0, 0, 100), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
