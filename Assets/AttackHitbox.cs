using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] String targetTag = "Enemy";
    [SerializeField] float attackDamage = 10f;
    [SerializeField] float attackStun = 0.1f;
    [SerializeField] float attackXKnockback = 30f;
    [SerializeField] float attackYKnockback = 30f;
    
    List<Collider2D> hitEnemyColliders;  
    Collider2D col;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = transform.parent.gameObject;
        col = GetComponent<Collider2D>();
        hitEnemyColliders = new List<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == targetTag){
            collision.transform.gameObject.GetComponent<BaseStatus>().takeDamage(attackDamage, attackStun, attackXKnockback, attackYKnockback);
            Physics2D.IgnoreCollision(collision.transform.gameObject.GetComponent<Collider2D>(), col);
            hitEnemyColliders.Add(collision.transform.gameObject.GetComponent<Collider2D>());
            GetComponent<Animator>().SetBool("hit", true);
        }
    }

    public void ResetHitbox(){
        foreach(Collider2D enemyCollider in hitEnemyColliders){
            Physics2D.IgnoreCollision(enemyCollider, col, false);
        }
        hitEnemyColliders.Clear();
        GetComponent<Animator>().SetBool("hit", true);
    }
}
