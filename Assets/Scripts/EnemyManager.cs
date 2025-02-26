using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) // Press 'K' to kill the enemy
        {
            KillEnemy();
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) // Press 'Q' or 'E' to revive the enemy
        {
            ReviveEnemy();
        }
    }

    void KillEnemy()
    {
        animator.SetBool("Dead", true);
        Debug.Log("Enemy has died");
    }

    void ReviveEnemy()
    {
        animator.SetBool("Dead", false);
        Debug.Log("Enemy has revived");
    }
}