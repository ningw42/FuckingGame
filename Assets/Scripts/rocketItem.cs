using UnityEngine;
using System.Collections;

public class rocketItem : MonoBehaviour {

    public rocket m_rocket;
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
        if(other.gameObject.tag.Equals("Player"))
        {
            //get the player's component
            Player player = other.GetComponent<Player>();
            if(player!=null)
            {
                //get the player's current accleration
                Vector3 acceleration = player.acceleration;
                m_transform.eulerAngles = acceleration;
                //new a rocket in player's moving direction

                rocket clone = Instantiate(m_rocket, m_transform.position, player.transform.rotation) as rocket;
                acceleration.z = 0;
                clone.m_direction = acceleration;
                Destroy(this.gameObject);
            }
        }
    }
}
