using UnityEngine;
using System.Collections;

public class BoundHandle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (!other.gameObject.tag.Equals("Player") && !other.gameObject.tag.Equals("Bound"))
        {
            Destroy(other.gameObject);
        }
    }
}
