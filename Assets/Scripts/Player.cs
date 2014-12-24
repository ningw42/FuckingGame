using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float x = 0;
	float y = 0;
	int xedge;
	int yedge;
    public int m_life;
    Vector3 direction;
    Vector3 axis;
    public Vector3 acceleration;
    Transform m_transform;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
        m_transform = this.transform;
        m_life = 3;
		xedge = Screen.width;
		yedge = Screen.height;
        axis = new Vector3(0, 0, -1);
        direction = new Vector3(0, -1, 0);
	}

	void OnGUI (){
		GUI.Label (new Rect (10, 10, 100, 300), "x=" + x + " ,y=" + y);
		GUI.Label (new Rect (10, 50, 100, 100), xedge + ", " + yedge);
        GUI.Label(new Rect(10, 100, 100, 100), m_transform.position.x + " ," + m_transform.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        acceleration = Input.acceleration;
		x = acceleration.x * 30;
		y = acceleration.y * 30;
		if (m_transform.position.x + x > xedge >> 1)
			x = (xedge >> 1) - m_transform.position.x;
		else if (m_transform.position.x + x < - (xedge >> 1))
			x = -(xedge >> 1) - m_transform.position.x;

        if (m_transform.position.y + y > yedge >> 1)
			y = (yedge >> 1) - m_transform.position.y;
        else if (m_transform.position.y + y < -(yedge >> 1))
			y = -(yedge >> 1) - m_transform.position.y;
		m_transform.Translate (new Vector3(x, y, 0), Space.World);

        acceleration.z = 0;
        m_transform.rotation = Quaternion.LookRotation(-acceleration, axis);
	}

    private float calculateAngle(Vector3 acceleration, Vector3 direction)
    {
        acceleration.z = 0;
        direction.z = 0;
        return Mathf.Acos(dotProduct(acceleration, direction) / acceleration.magnitude / direction.magnitude);
    }

    private float dotProduct(Vector3 acceleration, Vector3 direction)
    {
        return acceleration.x * direction.x + acceleration.y * direction.y;
    }
}