using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
  public static bool isGamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
      GameEvents.current.OnTogglePause += TogglePauseGame;
    }

    void TogglePauseGame() {
      isGamePaused = !isGamePaused;
      if(isGamePaused) {
        Time.timeScale = 0f;
      } else {
        Time.timeScale = 1;
      }
    }
    
    void OnDestroy() {
      GameEvents.current.OnTogglePause -= TogglePauseGame;
    }
}
