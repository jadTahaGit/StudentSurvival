using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public int highscore = 0;
    public TextMeshProUGUI scoreUI;
    
    public TextMeshProUGUI highscoreUI;

    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore",0);
        scoreUI.text ="Score: " + score.ToString();
        highscoreUI.text ="Highscore: " + highscore.ToString();
        
    }

    public void AddPoint(){
        score +=1;
        scoreUI.text ="Score: " + score.ToString();
        if(highscore < score){
            PlayerPrefs.SetInt("highscore",score);
        }

    }
}
