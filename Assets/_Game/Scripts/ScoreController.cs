using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private float _score = 0; 
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnAsteroidHit += IncreaseScore;
    }

    void IncreaseScore(Asteroid a, Vector3 p)
    {
      _score += a.getScoreValue();
      GameEvents.current.ScoreChanged(_score);
    }
    
    public float GetScore()
    {
        return _score;
    }

    void OnDestroy() {
      GameEvents.current.OnAsteroidHit -= IncreaseScore;
    }

}
