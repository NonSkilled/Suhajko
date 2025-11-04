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
    }
    





}
