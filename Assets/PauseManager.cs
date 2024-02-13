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
    public GameObject ItemPanel;
    public GameObject InventoryGroup;
    public GameObject PlayerPanel;
    public GameObject MainGroup;
    public void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        GamePaused = !GamePaused;

        if(GamePaused)
        {
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
            PlayerPanel.SetActive(true);
            MainGroup.SetActive(true);
            InventoryGroup.SetActive(false);
            ItemPanel.SetActive(false);
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
