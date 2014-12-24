using UnityEngine;
using System.Collections;

public class RedDot2 : MonoBehaviour {
    Vector3 direction;
    Transform m_transform;
    public int m_speed;

	// Use this for initialization
	void Start () {
        m_speed = 5;
        m_transform = this.transform;
        direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
        m_transform.Translate(direction * m_speed);
	}

    void OnTriggerEnter(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.tag.Equals("Player"))
        {
            //((Player)enteredObject).m_life--;
        }
    }
}
