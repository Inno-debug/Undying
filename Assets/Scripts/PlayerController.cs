using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float baseSpeed;
    public float acceleration;
    public float maxSpeed;
    public int side;
    [SerializeField] KeyCode jump;
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode slide;

    [SerializeField] float slideForce;
    
    int previousDir = 0;
    
    float moveSpeed;

    public bool grounded = false;

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
        if (Input.GetAxisRaw("Horizontal") > 0){
            side = 1;
            Quaternion playerRotation = Quaternion.identity;
            playerRotation.eulerAngles = new Vector3(0, 0, 0);
            transform.rotation = playerRotation;
        }
        if(Input.GetAxisRaw("Horizontal") < 0){
            side = -1;
            Quaternion playerRotation = Quaternion.identity;
            playerRotation.eulerAngles = new Vector3(0, 180, 0);
            transform.rotation = playerRotation;
        }
        if (previousDir != (int)Input.GetAxisRaw("Horizontal")){
            moveSpeed = baseSpeed;
            previousDir = (int)Input.GetAxisRaw("Horizontal");
        }
        else{
            moveSpeed = Mathf.Min(moveSpeed + acceleration*Time.deltaTime, maxSpeed);
        }
        anim.SetFloat("yVelocity", rb.linearVelocityY);
        anim.SetBool("grounded", grounded); 
        if (Input.GetKeyDown(jump) && grounded){
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(slide) && grounded){
            rb.AddForceX(slideForce*side, ForceMode2D.Impulse);
            anim.SetTrigger("slide");
        }
        if (Input.GetMouseButtonDown(0)){
            anim.SetTrigger("leftClick");
        }
        if (Input.GetMouseButtonDown(1)){
            anim.SetTrigger("rightClick");
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal")*moveSpeed, rb.linearVelocity.y);
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")*moveSpeed));
    }
}
