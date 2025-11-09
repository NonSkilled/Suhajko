using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 3;
    public float freezeTimer = 0.2f;
    public int amount = 10;
    public FreezeManager freezeBar;
    public Player_movement playerMovement;
    public PauseMenu pauseMenu;





    private void Start()
    {
        health = maxHealth;
        freezeBar.SetFreeze(freezeBar.freeze);
        InvokeRepeating("FreezeOT", freezeTimer, freezeTimer);
    }

    public void Update()
    {
        
    }
    public void FreezeOT()
    {
        TakeFreeze(0.05f);
    }
    public void TakeFreeze(float amount)
    {
        freezeBar.freeze += amount;
        freezeBar.SetFreeze(freezeBar.freeze);
        if (freezeBar.freeze <= 50)
        {
            playerMovement.slow = 1f;
        }
        else if (freezeBar.freeze <= 75)
        {
            playerMovement.slow = 0.5f;
        }
        else if (freezeBar.freeze <= 99)
        {
            playerMovement.slow = 0.25f;
        }
        else
        {
            freezeBar.freeze = 0f;
            pauseMenu.TakeDamage();
        }
    }
    





}
