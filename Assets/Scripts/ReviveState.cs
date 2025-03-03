using UnityEngine;

public class ReviveState : StateMachineBehaviour
{
    public float speed = 2.5f;
    Transform player;
    Rigidbody2D rb;
    int stepCounter = 0;
    int stepLimit = 500;
    bool movingRight = true;
    Vector3 lastPlayerPosition;
    bool isPlayerMoving;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        rb.gameObject.layer = 6;
        stepCounter = 0;
        movingRight = true;
        lastPlayerPosition = player.position;
        isPlayerMoving = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("Dead"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetBool("Revived", true);
            }
            else if (animator.GetBool("Revived"))
            {
                

                
                if (isPlayerMoving)
                {
                    FollowPlayer();
                }
                else
                {
                    MoveEnemy();
                }
            }
        }
        
    }


    void FollowPlayer()
    {
        
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if(newPos == target)
        {
            isPlayerMoving = false;
        }
    }

    void MoveEnemy()
    {
        Vector2 newPos = rb.position;
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
            isPlayerMoving = true;
        }
        else if (movingRight)
        {
            newPos = rb.position + Vector2.right * speed * Time.fixedDeltaTime;
            stepCounter++;
            if (stepCounter >= stepLimit)
            {
                movingRight = false;
                stepCounter = 0;
                stepLimit = 100; // Change step limit to 100 after the first 50 steps
            }
        }
        else
        {
            newPos = rb.position + Vector2.left * speed * Time.fixedDeltaTime;
            stepCounter++;
            if (stepCounter >= stepLimit)
            {
                movingRight = true;
                stepCounter = 0;
            }
        }
        rb.MovePosition(newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
