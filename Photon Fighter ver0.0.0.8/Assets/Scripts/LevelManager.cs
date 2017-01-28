using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public GameObject player;
    public int sceneIndex = 0;
    public float sceneLoadDelay = 10.0f;
    public float sceneTime = 0.0f;
    public float sceneActiveDelay = 5.0f;
    public float sceneActiveDuration = 5.0f;

    private Canvas Title;
    private Canvas UI;
    private Canvas gameOverCanvas;
    private Text levelTime;
    private Text gameOver;
    private Health playerHealth;
    public bool playing = false;
    public int lastSceneIndex = 1;
    private Image healthBar1;
    private Image healthBar2;
    private Image healthBar3;



    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        player = GameObject.FindGameObjectWithTag("Player");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Canvas[] canvases = GetComponentsInChildren<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            if (canvas.name.Equals("TitleCanvas"))
            {
                Title = canvas;
            }
            else if (canvas.name.Equals("UI"))
            {
                UI = canvas;
                UI.enabled = false;
            }
            else if (canvas.name.Equals("GameOverCanvas"))
            {
                gameOverCanvas = canvas;
                gameOverCanvas.enabled = false;
            }
        }

        Text[] uiTextComponents = UI.GetComponentsInChildren<Text>();
        foreach (Text component in uiTextComponents)
        {
            if (component.name.Equals("LevelTime"))
            {
                levelTime = component;
            }
        }

        Image[] healthBar = UI.GetComponentsInChildren<Image>();
        foreach (Image component in healthBar)
        {
            if (component.name.Equals("LifeSegment1"))
            {
                healthBar1 = component;
            }
            else if (component.name.Equals("LifeSegment2"))
            {
                healthBar2 = component;
            }
            else if (component.name.Equals("LifeSegment3"))
            {
                healthBar3 = component;
            }
        }



    }

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    

    // Update is called once per frame
    void Update()
    {
        sceneTime += Time.deltaTime;
        levelTime.text = (sceneActiveDuration - sceneTime).ToString("F2");

        if (playing == true && player == null && sceneIndex != 0 && sceneIndex != lastSceneIndex)
        {
            GameOver(false);
        }

        if (playing = true && player != null)
        {
            
            if (sceneActiveDuration - sceneTime <= 0)
            {
                LoadNextScene();
            }
            

            if (playerHealth.health > 3)
            {
                playerHealth.health = 3;
            }

            switch (playerHealth.health)
            {
                case 0:
                    {
                        GameOver(false);
                        break;
                    }
                case 1:
                    {
                        healthBar1.enabled = true;
                        healthBar2.enabled = false;
                        healthBar3.enabled = false;
                        break;
                    }
                case 2:
                    {
                        healthBar1.enabled = true;
                        healthBar2.enabled = true;
                        healthBar3.enabled = false;
                        break;
                    }
                case 3:
                    {
                        healthBar1.enabled = true;
                        healthBar2.enabled = true;
                        healthBar3.enabled = true;
                        break;
                    }
                default:
                    {
                        GameOver(false);
                        break;
                    }
            }







        }

        


        /*if (sceneIndex == 0 && sceneTime > sceneLoadDelay)
        {
            LoadNextScene();   
        }*/
    }

    void LoadNextScene()
    {
        if (sceneIndex + 1 == lastSceneIndex)
        {
            GameOver(true);
        }
        if (SceneManager.GetSceneByBuildIndex(sceneIndex + 1) != null)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);

        }
    }

    void OnSceneLoaded(Scene previousScene, LoadSceneMode loadSceneMode)
    {
        Debug.Log(sceneIndex);
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playing = true;
            playerHealth = player.GetComponent<Health>();

        }
        sceneTime = 0.0f;
    }

    public void StartGame()
    {
        Debug.Log("Start");
        UI.enabled = true;
        Title.enabled = false;
        gameOverCanvas.enabled = false;
        sceneIndex = 1;
        SceneManager.LoadScene(1);
    }



    public void QuitGame()
    {
        Debug.Log("Quit");
        //NOTE Do not do this if exporting to mobile
        Application.Quit();
    }

    public void GameOver(bool finishedGame)
    {
        //TODO: Get scene index dynamically
        //TODO: use finishedGame to set the text to Win or Lose in UI before displaying it.
        Debug.Log("GameOver");
        UI.enabled = false;
        Title.enabled = false;
        gameOverCanvas.enabled = true;
        sceneIndex = lastSceneIndex;
        playing = false;
        SceneManager.LoadScene(lastSceneIndex);
    }


}
