using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth;

    private void Start()
    {
        health = maxHealth;
    }
}
