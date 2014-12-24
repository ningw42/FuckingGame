using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {

    //protected AudioSource m_audio;


    public Transform m_explosionFX;

    //live time
    public float m_livetime = 3;
    public Transform m_destroy;
    protected Transform m_transform;
	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        m_livetime -= Time.deltaTime;
        if (m_livetime <= 0)
            Destroy(this.gameObject);
	}

    void OnTriggerEnter(Collider other)
    {
        //if player enters the collision area
        if(other.tag.Equals("Player"))
        {
            Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            //create a sphere to destroy enemy entering the collison area
            Instantiate(m_destroy,m_transform.position, m_transform.rotation);
        }
    }
}
