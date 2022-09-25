using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private GameObject player;
    public bool isOnQuest = false;
    [SerializeField] GameManager gManager;
    public GameObject questCanvas;
    void Awake()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isOnQuest = false;
        // no use, need to singleton
       // player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("ddddddddD");
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("ddddddddD");
            isOnQuest = true;
            other.gameObject.GetComponent<PlayerController>().isOnQuest = isOnQuest;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOnQuest = false;
            other.gameObject.GetComponent<PlayerController>().isOnQuest = isOnQuest;
        }

    }
    public void questDone()
    {
        //Debug.Log("APPUYER POUR QUEST quest trigger");
        gManager.randomSpawn(gManager.listSpawn);
        questCanvas.SetActive(false);
        Destroy(gameObject);
        gManager.canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isOnQuest)
        {
            //Debug.Log("APPUYER POUR QUEST quest trigger");
            //gManager.randomSpawn();
            questCanvas.SetActive(true);
            //Destroy(gameObject);

        }
        if(questCanvas.activeSelf == true)
        {
            gManager.canMove = false;
        }
    }
}
