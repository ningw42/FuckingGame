using UnityEngine;
using System.Collections;

public class blackholeItem : MonoBehaviour {
    public blackHole m_blackhole;
    protected Transform m_transform;

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        //player enters the collision area
        if (other.tag.Equals("Player"))
        {
            //get the player's component
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Instantiate(m_blackhole, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
