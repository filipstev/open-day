using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ball, startButton, highScoreText, scoreText, quitButton, restartButton;

    int score, highScore;

    [SerializeField]
    Rigidbody2D left, right;


    [SerializeField]
    Vector3 startPos;

    public int multiplier;

    Boolean canPlay;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1;
        score = 0;
        multiplier = 1;
        highScore = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
        highScoreText.GetComponent<TMP_Text>().text = "HighScore: " + highScore;
        canPlay = false;

    }

    private void Update()
    {
        if (!canPlay) return;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            left.AddTorque(25f);
        }
        else
        {
            left.AddTorque(-20f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            right.AddTorque(-25f);
        }
        else
        {
            right.AddTorque(20f);
        }

    }

    public void UpdateScore(int point, int mullIncrease)
    {
        multiplier += mullIncrease;
        score += point * multiplier;
        Debug.Log(score);
        scoreText.GetComponent<TMP_Text>().text = "Score: " + score;

    }

    public void GameEnd()
    {
        Time.timeScale = 0;
        highScoreText.SetActive(true);
        quitButton.SetActive(true);
        restartButton.SetActive(true);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;

        }
        highScoreText.GetComponent<TMP_Text>().text = "HighScore: " + highScore;
    }

    public void GameStart()
    {
        highScoreText.SetActive(false);
        startButton.SetActive(false);
        scoreText.SetActive(true);
        Instantiate(ball, startPos, Quaternion.identity);
        Debug.Log("Tekst");
        canPlay = true;
    }

    public void GameQuit()
    {
 #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
 #endif
        Application.Quit(); 
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
