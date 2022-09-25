using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager cela;
    public List<GameObject> listSpawn = new List<GameObject>();
    public List<GameObject> listSpawnCafe = new List<GameObject>();
    [SerializeField] Canvas pauseMenuUI;
    public bool canMove = true;

    public static GameManager instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<GameManager>();
            return cela;
        }
    }
    
    // Start is called before the first frame update
    
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject winUI;
    private bool isWin;
    private bool gameOver;
    [SerializeField] int cafeToHave = 1;
    public int cafeAtm = 0;

    void Awake()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag("SpawnQuest");
        foreach (GameObject item in a)
        {
            Debug.Log("fhqudsfhqusid");
            listSpawn.Add(item);
        }
        GameObject[] b = GameObject.FindGameObjectsWithTag("cafeSpawn");
        foreach (GameObject item in b)
        {
            listSpawnCafe.Add(item);
        }

    }
    void Start()
    {
        if(gameOverUI) gameOverUI.SetActive(false);
        if(pauseUI) pauseUI.SetActive(false);
        if (winUI) winUI.SetActive(false);
        DoPause(false);
    }
    public void GameOver(bool isGameOver)
    {
        gameOver = isGameOver;
        gameOverUI.SetActive(true);
        DoPause(isGameOver);
    }
    public void addCafe()
    {
        cafeAtm += 1;
        //Debug.Log("addcafe" + cafeAtm);
        if(cafeAtm == cafeToHave)
        {
            //Debug.Log("on est dans le if de addcafe");
            cafeAtm = 0;
            
            GetComponent<EnduranceJauge>().switchRoutine(true);
        }
    }
    public void randomSpawn(List<GameObject> tab)
    {
        //Debug.Log("list count " + tab.Count);
        int randomNumber = Random.Range(0, tab.Count);
        //Debug.Log("list random " + randomNumber);
        tab[randomNumber].GetComponent<SpawnQuest>().spawnObject();
    }
    public void Win()
    {
        isWin = true;
        winUI.SetActive(true);
        DoPause(true);
    }

    private void DoPause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }
    public void triggerFakePause(bool a)
    {
        pauseMenuUI.gameObject.SetActive(a);
    }
    public void pauseMenu()
    {
        if (pauseUI.activeSelf)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1.0f;
            
        }
        else
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }
    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetButtonDown("Submit") && (gameOver || isWin))
        {
            SceneManager.LoadScene("Level1");
        }*/
/*        if (Input.GetButtonDown("Start"))
        {
            pauseMenu();
        }*/
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLevel()
    {
        
        SceneManager.LoadScene("Level1");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
        Application.OpenURL("about:blank");
#endif
        Application.Quit();
    }
}
