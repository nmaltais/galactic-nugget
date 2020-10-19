using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    // Start is called before the first frame update
    private Text _scoreText;
    void Start()
    {
        _scoreText = GetComponent<Text>();
        GameEvents.current.OnScoreChanged += DisplayNewScore;
    }

    void DisplayNewScore(float newScore) {
        _scoreText.text = "Score: " + newScore.ToString();  
    }

    void OnDestroy() {
      GameEvents.current.OnScoreChanged -= DisplayNewScore;
    }
}
