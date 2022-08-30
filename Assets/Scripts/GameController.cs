using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Material[] skybox;

    private Player player;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text gameOverScoreText;

    //[SerializeField]
    //private Text winScoreText;

    [HideInInspector]
    public float score;

    [SerializeField]
    private GameObject gameOverPanel;

    private float timer;
    private float timeBtwSky = 30f;

    [SerializeField]
    private GameObject gamePanel;

    private int skyBoxIndex = 0;

    public static GameController instance;
    
	// Use this for initialization
	void Start ()
    {
        if(instance == null)
        {
            instance = this;
        }
        player = GameObject.Find("Player").GetComponent<Player>();
        RenderSettings.skybox = skybox[0];
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timer >= timeBtwSky && skyBoxIndex <= skybox.Length)
        {
            skyBoxIndex++;
            RenderSettings.skybox = skybox[skyBoxIndex];
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if(player.playerIsDead)
        {
            gameOverPanel.SetActive(true);
            gameOverScoreText.text = "Score: " + score.ToString("0");
            gamePanel.SetActive(false);
        }
        else
        {
            score += Time.deltaTime;
            scoreText.text = score.ToString("0");
        }
	}
}
