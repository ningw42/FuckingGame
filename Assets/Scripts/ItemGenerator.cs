using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {
    public float time_delay = 2;
    public Transform m_blackhole;
    public Transform m_wave;
    public Transform m_bomb;
    public Transform m_frozen;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time_delay -= Time.deltaTime;
        if (time_delay <= 0)
        {
            generateItem();
            Destroy(this.gameObject);
        }
	}

    private void generateItem()
    {
        int token = Random.Range(0, 4);
        Transform target = m_bomb;
        switch (token)
        {
            case 0: target = m_blackhole; break;
            case 1: target = m_bomb; break;
            case 2: target = m_frozen; break;
            case 3: target = m_wave; break;
        }

        Instantiate(target, generatePos(), Quaternion.identity);
    }

    private Vector3 generatePos()
    {
        int width = Screen.width - 50;
        int height = Screen.height - 50;
        int x = Random.Range(- width / 2 , width / 2);
        int y = Random.Range(-height / 2, height / 2);
        return new Vector3(x, y, 100);
    }
}
