using UnityEngine;
using System.Collections;

public class rocketSource : MonoBehaviour {

    public Transform m_rocket;
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
        Debug.Log(other.gameObject.name);

        if(other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("fuck player");
            //get the player's component
            Player player = other.GetComponent<Player>();
            if(player!=null)
            {
                //get the player's current accleration
                Vector3 acceleration = player.acceleration;
                Debug.Log(acceleration);
                m_transform.eulerAngles = acceleration;
                //new a rocket in player's moving direction
                Object clone = Instantiate(m_rocket, m_transform.position, player.transform.rotation);
                
                Destroy(this.gameObject);
            }
        }
    }
}
