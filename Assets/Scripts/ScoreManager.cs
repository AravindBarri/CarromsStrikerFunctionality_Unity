using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreInstance;

    Text ScoreText;
    private int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreInstance = this;
        ScoreText = this.GetComponent<Text>();
    }

    public void RedPuckUpdate()
    {
        Score += 20;
        ScoreText.text = "Score : " + Score;
    }
    public void BluePuckUpdate()
    {
        Score += 10;
        ScoreText.text = "Score : " + Score;
    }
}
