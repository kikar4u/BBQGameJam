using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class addScore : MonoBehaviour
{
    public TMP_Text scoreGame;
    GameManager gManager;
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        scoreGame = GameObject.FindGameObjectWithTag("score").GetComponent<TMP_Text>();
    }

    public void updateScore()
    {
        Debug.Log(scoreGame.text);
        scoreGame.text = gManager.score.ToString();
    }
}
