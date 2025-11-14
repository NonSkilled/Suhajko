using System;
using JetBrains.Annotations;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool afterlife = false;
    public GameObject PauseMenuUI;
    public GameObject DeathMenuUI;
    public GameObject FinalDeathMenuUI;
    public PlayerHealth PlayerHealth;
    public Vector3 spawnPosition;

    void Update()
    {
        if (afterlife == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
            
            
        
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
    public void LoadGame()
    {
        afterlife = false;
        SceneManager.LoadScene(1);
    }
    public void Death()
    {
        PlayerHealth.health -= 1;
        DeathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        afterlife = true;
    }
    public void Respawn()
{
    afterlife = false;
    PlayerHealth.transform.position = spawnPosition;
    PlayerHealth.health = 3;
    FinalDeathMenuUI.SetActive(false);
    Time.timeScale = 1f;


}
    public void TakeDamage()
    {
            if (afterlife != true)
            {
                if (PlayerHealth.health > 1)
                {
                    //Time.timeScale = 0f;
                    PlayerHealth.health -= 1;

                }
                else if (PlayerHealth.health == 1)
                {
                    Time.timeScale = 0f;
                    PlayerHealth.health -= 1;
                    FinalDeathMenuUI.SetActive(true);
                    //SceneManager.LoadScene(1);

                }
                else
                {
                    
                    //Death();

                }
            }
        
    }
}
