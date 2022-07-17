using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("score").ToString();
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("gameplay");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Startmenu");
    }
}
