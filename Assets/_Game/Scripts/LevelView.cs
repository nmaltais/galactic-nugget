using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    private Text _levelText;
    // Start is called before the first frame update
    void Start()
    {
        _levelText = GetComponent<Text>();
        GameEvents.current.OnLevelChanged += DisplayNewLevel;
    }

    void DisplayNewLevel(Level newLevel) {
        _levelText.text = "Level: " + newLevel.id.ToString();
    }

    void OnDestroy() {
        GameEvents.current.OnLevelChanged -= DisplayNewLevel;
    }
}
