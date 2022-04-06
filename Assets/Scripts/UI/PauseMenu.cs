using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    [SerializeField] public GameObject pauseMenuUI;
    [SerializeField] public GameObject OptionsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if(OptionsMenuUI == isActiveAndEnabled)
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Back()
    {
        pauseMenuUI.SetActive(true);
        OptionsMenuUI.SetActive(false);
    }
    public void Options()
    {
        pauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
