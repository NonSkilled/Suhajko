using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 3;
    private void Start()
    {
        health = maxHealth;
        
    }

   

    
}
