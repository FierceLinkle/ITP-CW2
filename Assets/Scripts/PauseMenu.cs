using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public FirstPersonController fps;

    public Text TimerText;
    float t = 0;
    private float startTime;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        //Debug
        if (Input.GetKeyDown("b"))
        {
            PauseTimer();
        } 
        else if (Input.GetKeyDown("n"))
        {
            UnPauseTimer();
        }
        else if (Input.GetKeyDown("m"))
        {
            ResetTimer();
        }

        if (paused)
            return;

        //t = Time.time - startTime;
        t += Time.deltaTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        TimerText.text = "Time: " + minutes + ":" + seconds;
    }

    public void Resume()
    {
        fps.m_MouseLook.SetCursorLock(true);
        fps.enabled = true;
        UnPauseTimer();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        fps.m_MouseLook.SetCursorLock(false);
        fps.enabled = false;
        PauseTimer();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        fps.m_MouseLook.SetCursorLock(true);
        fps.enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting game");
    }

    public void PauseTimer()
    {
        paused = true;
        TimerText.color = Color.yellow;
    }

    public void UnPauseTimer()
    {
        paused = false;
        TimerText.color = Color.white;
    }

    public void ResetTimer()
    {
        t = 0;
        TimerText.color = Color.white;       
    }
}
