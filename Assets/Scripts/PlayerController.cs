using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private Vector2 movement;

    void Start()
    {
        
    }

    
    void Update()
    {

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
       
    }

    private void FixedUpdate()
    {
        
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);  

    }
}
