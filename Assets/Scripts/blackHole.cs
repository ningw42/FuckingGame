using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class blackHole : MonoBehaviour {
	public Vector3 gravity;
    public Transform m_transform;
    public float m_lifetime = 5;

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        m_lifetime -= Time.deltaTime;
        if (m_lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
	}

	void OnTriggerEnter( Collider other )
	{ 
	} 

	void OnTriggerStay( Collider other)
	{
        GameObject inrangeObject = other.gameObject;
        string tag = other.tag;
        if ((inrangeObject.transform.position - m_transform.position).magnitude < 5)
        {
            if (tag.Equals("Reddot_1") || tag.Equals("Reddot_2"))
            {
                GameManager.Instance.AddScore(1);
                Destroy(inrangeObject);
            }
        }
        else
        {
            if (tag.Equals("Reddot_1") || tag.Equals("Reddot_2") || tag.Equals("Player"))
            {
                if (Time.deltaTime != 0)
                {
                    gravity = m_transform.position - inrangeObject.transform.position;
                    gravity = gravity.normalized * 100 / (gravity.magnitude < 5 ? 5 : gravity.magnitude);
                    inrangeObject.transform.Translate(gravity, Space.World);
                }
            }
        }
	}

	void OnTriggerExit( Collider other )
	{
	} 

	void FixedUpdate ()
	{
	}
}
