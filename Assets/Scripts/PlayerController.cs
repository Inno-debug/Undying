using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float baseSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] KeyCode jump;
    [SerializeField] float jumpForce;
    
    int previousDir = 0;
    
    float moveSpeed;

    public bool grounded = false;

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (previousDir != (int)Input.GetAxisRaw("Horizontal")){
            moveSpeed = baseSpeed;
            previousDir = (int)Input.GetAxisRaw("Horizontal");
        }
        else{
            moveSpeed = Mathf.Min(moveSpeed + acceleration*Time.deltaTime, maxSpeed);
        }
        if (Input.GetKeyDown(jump) && grounded){
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
        

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal")*moveSpeed, rb.linearVelocity.y);
    }
}
