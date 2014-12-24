using UnityEngine;
using System.Collections;

public class RedDot1Generator : MonoBehaviour {
	public Transform reddot_1;
	private int timer = 0;

	// Use this for initialization
	void Start () 
    {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "reddot.jpg", false);
    }
	// Update is called once per frame
	void Update () 
    {
		if (timer++ == 100) {
			timer = 0;
			Instantiate(reddot_1, this.transform.position, Quaternion.identity);
		}
	}
}
