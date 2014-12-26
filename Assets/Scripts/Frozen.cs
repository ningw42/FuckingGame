using UnityEngine;
using System.Collections;

public class Frozen : MonoBehaviour {

    protected ArrayList mylist1;
    protected ArrayList mylist2;
    public float m_livetime = 5;
    public Transform m_frozenFX;
    protected Transform froz;
	// Use this for initialization
	void Start () {
        mylist1 = new ArrayList();
        mylist2 = new ArrayList();
        froz = Instantiate(m_frozenFX, transform.position, transform.rotation) as Transform;
	}
	
	// Update is called once per frame
	void Update () {
        m_livetime -= Time.deltaTime;
        if (m_livetime <= 0)
        {
            //free the ball being frozen
            foreach(RedDot1 reddot in mylist1)
            {
                reddot.isFrozen = false;
            }
            foreach (RedDot2 reddot in mylist2)
            {
                reddot.isFrozen = false;
            }
            Destroy(froz.gameObject);
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Reddot_1"))
        {
            RedDot1 red1 = other.GetComponent<RedDot1>();
            if(red1!=null)
            {
                red1.isFrozen = true;          //froze the ball
                mylist1.Add(red1);
            }
            
        }
        else if(other.tag.Equals("Reddot_2"))
        {
            RedDot2 red2 = other.GetComponent<RedDot2>();
            if(red2!=null)
            {
                red2.isFrozen = true;
                mylist2.Add(red2);
            }
           
        }
        else
        {

        }
    }
}
