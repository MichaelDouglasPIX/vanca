using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Attributes")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask stairsLayer;
    [SerializeField] private Transform footPosition;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    private float direction = 0;
    private bool ground;
    private int action;
    public bool ladder;
    private void FixedUpdate() {
        if(Input.GetMouseButton(0)){
            action = 1;
        }else{
            action = 0;
        }
        if(action == 1){
            StandartAction();           
        }
        ground = Ground();
        Animations();
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
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(footPosition.position, 0.05f);
        Gizmos.DrawWireSphere(transform.position, 0.12f);
    }
}
