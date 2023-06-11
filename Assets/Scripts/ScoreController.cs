using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
    public int Score
    {
        get { return score;}
        set { score = value;}
    }
    private int maxScore = 30;
    public int MAX_SCORE
    {
        get { return maxScore;}
    }
    private void Awake() {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }
    public void increaseScore(int increment){
        score += increment;
        RefreshUI();
    }
    private void RefreshUI(){
        scoreText.text = "Score: " + score;
    }
}
