using UnityEngine;
using System.Collections;

public class iceItem : MonoBehaviour {

    public Transform m_Frozen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            Instantiate(m_Frozen, this.transform.position, Quaternion.identity);
            GameManager.Instance.m_itemCount--;
            Destroy(this.gameObject);
        }
    }
}
