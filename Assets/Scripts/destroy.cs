using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

    public float m_livetime = 5;
    public Transform m_explosionFX;
    protected Transform exp;
	// Use this for initialization
	void Start () {
        exp = Instantiate(m_explosionFX, transform.position, transform.rotation) as Transform;
	}
	
	// Update is called once per frame
	void Update () {
        m_livetime -= Time.deltaTime;
        if (m_livetime <= 0)
        {
            Destroy(exp.gameObject);
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        //if player enters the collision area
        if (other.tag.Equals("Reddot_1") || other.tag.Equals("Reddot_2"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.AddScore(1);
        }
    }
}
