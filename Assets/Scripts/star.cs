using UnityEngine;
using System.Collections;

public class star : MonoBehaviour {

    private float speed;
	// Use this for initialization
	void Start () {
        speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
        // Scroll main texture based on time

		float offset = Time.time * speed;
		renderer.material.SetTextureOffset ("_MainTex", new Vector2(offset,0));
	
	}
}
