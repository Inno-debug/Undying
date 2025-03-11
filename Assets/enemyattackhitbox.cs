using UnityEngine;
using System.Collections;

public class enemyattackhitbox : MonoBehaviour
{
    private Animator animator;
    public float knockbackForce = 1000f;
    public float knockbackDuration = 0.2f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");

            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * knockbackForce);
            }
        }
    }

 
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.ResetTrigger("Attack");
        }
    }
}