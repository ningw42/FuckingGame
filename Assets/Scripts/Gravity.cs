using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public Vector3 gravity;

	// Use this for initialization
	void Start () {
		gravity.x = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter( Collider other )
	{ 
		Debug.Log("in " + other.gameObject.name); 
	} 

	void OnTriggerStay( Collider other)
	{
        GameObject inrangeObject = other.gameObject;
        if ((inrangeObject.transform.position - transform.position).magnitude < 5 && !inrangeObject.tag.Equals("Player"))
        {
            GameManager.Instance.AddScore(1);
            Destroy(inrangeObject);
        }
        gravity = transform.position - inrangeObject.transform.position;
        gravity = gravity.normalized * 100 / (gravity.magnitude < 5 ? 5 : gravity.magnitude);
        inrangeObject.transform.Translate(gravity, Space.World);
	}

	void OnTriggerExit( Collider other )
	{
		Debug.Log("out" + other.gameObject.name); 
	} 

	void FixedUpdate ()
	{
	}
}
