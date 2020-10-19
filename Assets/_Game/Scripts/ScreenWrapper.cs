using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    Renderer[] renderers;
    Camera cam;
    bool isWrappingX = false;
    bool isWrappingY = false;
 
    void Start()
    {
        cam = Camera.main;
        renderers =  GetComponentsInChildren<Renderer>();
    }

    void Update() {
      ScreenWrap();
    }

    public bool IsVisible(Renderer renderer)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
    
    bool CheckRenderers()
    {
        foreach(Renderer renderer in renderers)
        {
            // If at least one render is visible, return true
            if(IsVisible(renderer))
            {
                return true;
            }
        }
    
        // Otherwise, the object is invisible
        return false;
    }


    void ScreenWrap()
    {
        bool isVisible = CheckRenderers();

        if(isVisible)
        {
            isWrappingX = false;
            isWrappingY = false;
            return;
        }
    
        if(isWrappingX && isWrappingY) {
            return;
        }
    
        Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);
        Vector3 newPosition = transform.position;
    
        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;
    
            isWrappingX = true;
        }
    
        if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;
    
            isWrappingY = true;
        }
    
        transform.position = newPosition;
    }
}
