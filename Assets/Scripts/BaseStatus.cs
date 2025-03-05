using UnityEngine;

public class BaseStatus : MonoBehaviour
{
   // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float health;
    Animator anim;

    Rigidbody2D rb;
    float stunTimer = 0;

    

    public void takeDamage(float damage, float hitstun, float xKnockback, float yKnockback){
        health -= damage;
        stunTimer = hitstun;
        anim.SetBool("stunned", true);
        rb.linearVelocityX = 0f;
        rb.linearVelocityY = 0f;
        rb.AddForce(new Vector2(xKnockback, yKnockback), ForceMode2D.Impulse);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("stunned")){
            if (stunTimer <= 0){
                anim.SetBool("stunned", false);
            }
            else{
                stunTimer -= Time.deltaTime;
            }
        }

    }
}
