using UnityEngine;
using System.Collections;

public class RedDot2 : MonoBehaviour {
    Vector3 direction;
    Transform m_transform;
    public int m_speed = 100;
    public bool isFrozen;

	// Use this for initialization
	void Start () {
        isFrozen = false;
        m_transform = this.transform;
        direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
        if(!isFrozen)
        {
            m_transform.Translate(direction * m_speed * Time.deltaTime);
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
