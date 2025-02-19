using Unity.VisualScripting;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = transform.parent.gameObject;
        Debug.Log(player.name);      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll){
        Debug.Log("collision detected!");    
         if (coll.gameObject.tag == "Ground"){
            Debug.Log("It's the ground!");
            player.GetComponent<PlayerController>().grounded = true;
         }
    }
    void OnCollisionExit2D(Collision2D coll){
         if (coll.gameObject.tag == "Ground"){
            Debug.Log("Leaving ground!");
            player.GetComponent<PlayerController>().grounded = false;
         }
    }
}
