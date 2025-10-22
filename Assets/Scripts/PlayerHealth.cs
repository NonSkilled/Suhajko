using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 3;
    public float interval = 3f;
    private void Start()
    {
        health = maxHealth;
    }
    
    

   

    
}
