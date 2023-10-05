using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MusicControl;
    public GameObject GameOverPanel;

    AudioSource bgm;
    bool isStop = false;
   public void Home()
    {
        SceneManager.LoadScene("StartScene");
    } 
    public void Resume()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
        bgm.Play();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        Menu.SetActive(false);
        GameOverPanel.SetActive(false);
        bgm = MusicControl.GetComponentInChildren<AudioSource>();
    }
    private void Update()
    {
        if (isStop == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = true;
                Menu.SetActive(true);
                bgm.Pause();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
                isStop = false;
                Menu.SetActive(false);
                bgm.Play();
            }
        }

        //ÅÐ¶Ï½ÇÉ«ËÀÍö£¬ÔÝÍ£ÓÎÏ·
        if (GameController.gameScore <= 0)
        {
            Time.timeScale = 0;
            isStop = true;
            GameOverPanel.SetActive(true);
            bgm.Pause();
        }
    }
}
