using UnityEngine;
using System.Collections;

public class RedDot1Generator : MonoBehaviour {
	public Transform reddot_1;
    public float m_delta = 4;

	// Use this for initialization
	void Start () 
    {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "reddot.jpg", false);
    }
	// Update is called once per frame
	void Update () 
    {
        m_delta -= Time.deltaTime;
        if (m_delta <= 0)
        {
            m_delta = 4;
			Instantiate(reddot_1, this.transform.position, Quaternion.identity);
		}
	}
}
