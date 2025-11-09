using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public PauseMenu pauseMenu;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        //animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //foreach (Collider2D enemy in hitEnemies); //(pre viacerych enemakov)
        if (hitEnemies.Length > 0)
        {
            if (Time.time >= nextAttackTime)
            {
                pauseMenu.TakeDamage();
                nextAttackTime = Time.time + 1f / attackRate;
            }
                

        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    /*
    if (distance <= attackRange)
    {
        aiPath.canMove = false;  // stop movement
        aiPath.velocity = Vector3.zero;
        // trigger attack
    }
    else
    {
        aiPath.canMove = true;   // resume following
    }
    */

}
