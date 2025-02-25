using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerAttackFunctions : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float uppercutJumpForce = 18f;
    public GameObject Attacks;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }
    void FrontSlash(){
        Attacks.GetComponent<Animator>().SetTrigger("slash");
    }
    void Uppercut(){
        Attacks.GetComponent<Animator>().SetTrigger("uppercut");
    }
    void SpinningAttack(){
        Attacks.GetComponent<Animator>().SetTrigger("spinningAttack");
    }
    void JumpingUppercut(){
        rb.AddForceY(uppercutJumpForce, ForceMode2D.Impulse); 
        Attacks.GetComponent<Animator>().SetTrigger("uppercut");
    }
    
}
