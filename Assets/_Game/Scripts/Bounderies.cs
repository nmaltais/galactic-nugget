using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounderies : MonoBehaviour
{
    private Vector2 screenBoundsTop, screenBoundsBot;
    private float objWidth;
    private float objHeight; 
    private float objSize; 
    
    // Start is called before the first frame update
    void Start()
    {
        screenBoundsTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenBoundsBot = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, Camera.main.transform.position.z));
        objWidth = GetComponent<Collider>().bounds.size.x;
        objHeight = GetComponent<Collider>().bounds.size.y;
        objSize = objWidth > objHeight ? objWidth : objHeight;
        // objSizeScreen =  objSize * (Screen.width / (screenBoundsTop.x * 2));
    }
    // (1000,600) = (50, 30)  1000 / (50 * 2) = (screenUnit/worldUnit)
    // 100 world -> 1000 screen

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        if (viewPos.x < screenBoundsTop.x - objSize){ // Object goes off the left side
          viewPos.x = screenBoundsBot.x + objSize;
          transform.position = viewPos;
        }
        else if (viewPos.x > screenBoundsBot.x + objSize) { // Object goes off the right side
          viewPos.x = screenBoundsTop.x - objSize;
          transform.position = viewPos;
        }  
        if (viewPos.y < screenBoundsTop.y - objSize) { // Object goes off the bottom
          viewPos.y = screenBoundsBot.y + objSize;
          transform.position = viewPos;
        } 
        else if (viewPos.y > screenBoundsBot.y + objSize) { // Object goes off the top
          viewPos.y = screenBoundsTop.y - objSize;
          transform.position = viewPos;
        }

    }
}
