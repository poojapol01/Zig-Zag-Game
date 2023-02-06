using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;
    private int score=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        isGameStarted = true;
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseGameScore()
    {
        score++;
    }

    public int getScoreCount()
    {
        return score;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
}
