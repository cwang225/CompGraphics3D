using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    //public Button resumeButton;
    void Awake()
    {
        pauseMenu.SetActive(false);
        //resumeButton.onClick.AddListener(OnResumePressed);
    }
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            pauseMenu.SetActive(true);
            Debug.Log("pressed escape");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }

    public void OnResumePressed()
    {
        Debug.Log("resume pressed");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
