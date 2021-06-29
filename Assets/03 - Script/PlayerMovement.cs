using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Attributes")]
    [SerializeField] private PowerUps powerUps;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform footPosition;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    public bool ground;
    private int action;
    public bool ladder;

    private void FixedUpdate() {
        ActionManager(Input.GetMouseButton(0) ? 1 : 0);
        ground = Ground();
        Animations();
    }

    private void ActionManager(int currentAction){
        if(action == 1){
            StandartAction();           
        }else if(action == 0 && rb.velocity.x <= 0.01 && Input.GetMouseButton(0) && !ground){
            if(!ground && rb.velocity.y < 0.01){
                powerUps.Execute();
            } 
        }else if(action == 0 && ground){
            powerUps.Reset();
        }
        action = currentAction;
    }

    private void StandartAction(){
        if(ladder){
            rb.transform.position += new Vector3(0,action,0) * Time.deltaTime * moveSpeed /2;
        }else{
            transform.position += new Vector3(action,0,0) * Time.deltaTime * moveSpeed;
        }
    }   
    private void Animations(){
        ladderAnimation();
        animator.SetBool("stairs", ladder);
        animator.SetFloat("speed", action);
        animator.SetBool("ground", ground);
        animator.SetFloat("jump", rb.velocity.y);
    }
    private void ladderAnimation(){
        if(ladder && action == 1){
            animator.speed = 1;
        }
        else if(ladder && action == 0){
            animator.speed = 0;
        }
    }
    public bool Ground(){
        return Physics2D.OverlapCircle(footPosition.position, 0.05f, groundLayer);
    }

    public void allowPowerUp(){
        powerUps.Reset();
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(footPosition.position, 0.05f);
        Gizmos.DrawWireSphere(transform.position, 0.12f);
    }
}
