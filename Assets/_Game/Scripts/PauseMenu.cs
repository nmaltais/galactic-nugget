using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu; // Assign in inspector
    private bool _isShowing = false;

    void Start()
    {
      menu.SetActive(_isShowing);
      GameEvents.current.OnTogglePause += ToggleMenu;
    }

    void ToggleMenu() {
      _isShowing = !_isShowing;
      menu.SetActive(_isShowing);
    }

    void OnDestroy() {
      GameEvents.current.OnTogglePause -= ToggleMenu;
    }
}
