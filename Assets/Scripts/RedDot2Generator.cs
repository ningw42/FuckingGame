using UnityEngine;
using System.Collections;

public class RedDot2Generator : MonoBehaviour {
    public Transform reddot_2;
    public float m_delta = 2;

    // Use this for initialization
    void Start()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "reddot.jpg", false);
    }

    // Update is called once per frame
    void Update()
    {
        m_delta -= Time.deltaTime;
        if (m_delta <= 0)
        {
            m_delta = 2;
            Instantiate(reddot_2, this.transform.position, Quaternion.identity);
        }
    }
}
