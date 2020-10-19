using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController current = null;

    void Awake() {
      if(current == null)
      {
        current = this;
        DontDestroyOnLoad(gameObject);
      }
      else if (current != this)
      {
        Destroy(this);
      }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnPlayerWon += OnPlayerWon;
        GameEvents.current.OnRocketHitAsteroid += OnPlayerLost;
    }

    //Player Won
    void OnPlayerWon () {
      StartCoroutine("DelayedPlayerWonScene");
    }
    IEnumerator DelayedPlayerWonScene() {
      yield return new WaitForSeconds(1.5f);
      SceneManager.LoadScene("PlayerWon");
      yield return new WaitForSeconds(1.5f);
      SceneManager.LoadScene("MainMenu");
    }

    //Player Lost
    void OnPlayerLost (Asteroid a, Vector3 v) {
      StartCoroutine("DelayedGamePlayScene");
      // SceneManager.LoadScene("GamePlay"); 
    }
    IEnumerator DelayedGamePlayScene() {
      yield return new WaitForSeconds(1.5f);
      SceneManager.LoadScene("GamePlay"); 
    }

    void OnDestroy() {
      GameEvents.current.OnPlayerWon -= OnPlayerWon;
      GameEvents.current.OnRocketHitAsteroid -= OnPlayerLost;
    }
}
