using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsBallMove = false;
    public static int currentLevel = 10;
    public int score;
    public int lives;
    public int noBricks;
    public Text scoreText;
    public Text liveText;
    public Text noBricksText;
    public 
    void Start()
    {
        scoreText.text = "Score: " + score;
        liveText.text = "Lives: " + lives;
        noBricksText.text = "Bricks to Break: " + noBricks;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        liveText.text = "Lives: " + lives;
        
    }
    
    public void UpdateScores(int changeInScore)
    {
        score += changeInScore;
        scoreText.text = "Score: " + score;
        
    }

  
}
