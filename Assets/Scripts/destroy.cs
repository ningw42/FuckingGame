using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

    public float m_livetime = 1;
	// Use this for initialization
	void Start () {
       
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
        if (other.tag.Equals("Reddot_1"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.AddScore(1);
        }
    }
}
