using UnityEngine;
using System.Collections;
using System;

public class rocket : MonoBehaviour {

    //speed
    public float m_speed = 100;
    public float m_rotationX;
    public float m_rotationY;

    protected Transform m_transform;
	// Use this for initialization
	void Start () {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 90, this.transform.eulerAngles.z);
        m_transform = this.transform;

	}
	
	// Update is called once per frame
	void Update () {
        float angle_x = (float)Math.Cos(m_transform.rotation.x);
        float angle_y = (float)Math.Cos(m_transform.rotation.y);
       // float angle_x = 1;
        //float angle_y = 1;
        m_transform.Translate(new Vector3(-m_speed * Time.deltaTime * angle_x, -m_speed * Time.deltaTime * angle_y, 0));
	}

    void OnTriggerStay(Collider other)
    {
        if(other.tag.Equals("Reddot_1"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.AddScore(1);
        }
    }
}
