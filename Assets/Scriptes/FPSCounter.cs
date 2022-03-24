using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour
{
   
    private float fps = 0f;
  
    void OnGUI()
    {
        GUILayout.Label("FPS = " + (int)fps);
        fps = 1.0f / Time.deltaTime;
    }
}
