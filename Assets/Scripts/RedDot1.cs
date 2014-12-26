using UnityEngine;
using System.Collections;

public class RedDot1 : MonoBehaviour {
	float x;
	float y;
	float speed = 50;
	Vector3 direction;
    Vector3 delta;
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
            delta = direction * speed * Time.deltaTime;
            delta.z = 0;
            m_transform.Translate(delta);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.tag.Equals("Player"))
        {
            Player player = enteredObject.GetComponent<Player>();
            if (player != null)
            {
                player.m_life--;
            }
            Destroy(this.gameObject);
        }
    }
}
