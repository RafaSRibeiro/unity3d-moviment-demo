using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Animator animator;
    public Transform Player;
    Vector3 playerForward, playerRight;
    float currentSpeed, horMovement, vertMovement;
    

    void Start()
    {        
        PlayerInit();
    }
    // Update is called once per frame
    void Update()
    {
        horMovement = Input.GetAxis("Horizontal");
        vertMovement = Input.GetAxis("Vertical");
        SetVelocity();
        PlayerAnime();
        if (Input.anyKey) {
            PlayerMove();
        }        
    }

    void PlayerMove() {
                
        Vector3 direction = new Vector3(horMovement, 0, vertMovement);
        Vector3 rigthMovement = playerRight * currentSpeed * Time.deltaTime * horMovement;
        Vector3 upMovement = playerForward * currentSpeed * Time.deltaTime * vertMovement;

        Vector3 heading = Vector3.Normalize(rigthMovement + upMovement);

        transform.forward = heading;
        transform.position += rigthMovement;
        transform.position += upMovement;
    }

    void PlayerAnime() {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }
    }

    void PlayerInit() {
        playerForward = Player.forward;
        playerForward.y = 0;
        playerForward = Vector3.Normalize(playerForward);
        playerRight = Quaternion.Euler(new Vector3(0, 90, 0)) * playerForward;
    }

    void SetVelocity() {
        if ( horMovement != 0f && vertMovement != 0f)
            currentSpeed = speed * 0.6f;
        else     
            currentSpeed = speed * 1f;
    }

 
}
