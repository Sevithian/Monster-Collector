using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PauseManager : MonoBehaviour
{
    public bool GamePaused = false;
    public GameObject PauseCanvas;

    public void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    private void TogglePause()
    {
        GamePaused = !GamePaused;

        if(GamePaused)
        {
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
            return;
        }
        else if(!GamePaused)
        {
            Time.timeScale = 1;
            PauseCanvas.SetActive(false);
            return;
        }
    }
}
