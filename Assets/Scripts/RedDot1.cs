using UnityEngine;
using System.Collections;

public class RedDot1 : MonoBehaviour {
	float x;
	float y;
	float speed = 1;
	Vector3 direction;
	GameObject master;
    Transform master_transform;
    Transform m_transform;
    public bool isFrozen;

	// Use this for initialization
	void Start () {
        isFrozen = false;
		master = GameObject.FindGameObjectWithTag("Player");
        master_transform = master.transform;
        m_transform = this.transform;
		direction.z = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
        if(!isFrozen)
        {
            direction = (master_transform.position - m_transform.position).normalized;
            x = speed * direction.x;
            y = speed * direction.y;
            m_transform.Translate(x, y, 0);
        }
       
	}

    void OnTriggerEnter(Collider other)
    {

    }
}
