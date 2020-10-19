using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public InputController current;
    void Awake() {
      current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //Player Controls
      if(!PauseController.isGamePaused) {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
          GameEvents.current.PlayerRotateLeft();
        }
        if(Input.GetKey(KeyCode.D)  || Input.GetKey(KeyCode.RightArrow)){
          GameEvents.current.PlayerRotateRight();
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
          GameEvents.current.PlayerMoveForward();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
          GameEvents.current.PlayerShoot();
        }
      }

      //Menu Controls
      if(Input.GetKeyDown(KeyCode.P)){
        GameEvents.current.TogglePause();
      }
    }
}
