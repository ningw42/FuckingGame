using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // Itself
    public static GameManager Instance;

    // ItemGenerator
    public Transform itemGen;

    // Score
    public int m_score = 0;

    // Record
    public static int m_hiscore = 0;

    // Player
    protected Player m_player;

    // BGM Clip
    public AudioClip m_musicClip;

    // Audio Source
    protected AudioSource m_Audio;

    public int m_itemCount;

    public bool pause = false;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {

        m_Audio = this.audio;

        m_itemCount = 3;

        AddItem(); AddItem(); AddItem();

        // find Player
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            m_player = obj.GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        // BGM
        if (!m_Audio.isPlaying)
        {
            m_Audio.clip = m_musicClip;
            m_Audio.Play();
        }

        // Pause
        if (Time.timeScale > 0 && Input.touchCount > 0 && Input.GetTouch(0).tapCount == 2)
        {
            Time.timeScale = 0;
            pause = true;
        }

        if (m_player != null && m_player.m_life == 0)
        {
            Destroy(m_player.gameObject);
            Time.timeScale = 0;
        }
    }

    void OnGUI()
    {
        // Pause
        if (pause)
        {
            // Continue button
            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "Resume"))
            {
                Time.timeScale = 1;
                pause = false;
            }
        }

        int life = 0;
        if (m_player != null)
        {
            // Player life
            life = (int)m_player.m_life;
        }
        else // Game over
        {

            // Font
            GUI.skin.label.fontSize = 50;

            // Game over
            GUI.skin.label.alignment = TextAnchor.LowerCenter;
            GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "You Died");

            GUI.skin.label.fontSize = 20;

            // Again button
            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "Try Again"))
            {
                // Reload
                Application.LoadLevel ("OnGame");
                Time.timeScale = 1;
            }
        }

        GUI.skin.label.fontSize = 15;

        // Player lifeCount
        GUI.Label(new Rect(5, 5, 100, 30), "Life " + life);

        // Record
        GUI.skin.label.alignment = TextAnchor.LowerCenter;
        GUI.Label(new Rect(0, 5, Screen.width, 30), "Record " + m_hiscore);

        // Score
        GUI.Label(new Rect(0, 25, Screen.width, 30), "Score " + m_score);

    }

    // Score change
    public void AddScore(int point)
    {
        m_score += point;

        // Update record
        if (m_hiscore < m_score)
            m_hiscore = m_score;
    }

    public void AddItem()
    {
        // New ItemGenerator
        Instantiate(itemGen, new Vector3(0, 0, 0), Quaternion.identity);
        m_itemCount++;
    }
}
