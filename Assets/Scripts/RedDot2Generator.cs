using UnityEngine;
using System.Collections;

public class RedDot2Generator : MonoBehaviour {
    public Transform reddot_2;
    private int timer = 0;

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
        if (timer++ == 100)
        {
            timer = 0;
            Instantiate(reddot_2, this.transform.position, Quaternion.identity);
        }
    }
}
