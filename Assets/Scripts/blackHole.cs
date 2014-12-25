using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class blackHole : MonoBehaviour {
	public Vector3 gravity;
    public Transform m_transform;

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter( Collider other )
	{ 
	} 

	void OnTriggerStay( Collider other)
	{
        GameObject inrangeObject = other.gameObject;
        if ((inrangeObject.transform.position - m_transform.position).magnitude < 5)
        {
            Debug.Log(inrangeObject.tag);
            if (!other.tag.Equals("Player"))
            {
                GameManager.Instance.AddScore(1);
                Destroy(inrangeObject);
            }
        }
        else
        {
            gravity = m_transform.position - inrangeObject.transform.position;
            gravity = gravity.normalized * 100 / (gravity.magnitude < 5 ? 5 : gravity.magnitude);
            inrangeObject.transform.Translate(gravity, Space.World);
        }
	}

	void OnTriggerExit( Collider other )
	{
	} 

	void FixedUpdate ()
	{
	}
}
