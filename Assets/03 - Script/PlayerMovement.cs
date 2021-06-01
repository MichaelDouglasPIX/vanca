using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Attributes")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform footPosition;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    private float direction = 0;
    private bool ground;
    private bool falling;
    private void FixedUpdate() {
        ground = Ground();

        if(Input.GetMouseButton(0)){
            Walk(); 
        }else{
            animator.SetFloat("speed", 0);
        }

        animator.SetBool("ground", ground);
        animator.SetFloat("jump", rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        falling = false;
    }
    private void Walk(){
        transform.position += new Vector3(1,0,0) * Time.deltaTime * moveSpeed;
        animator.SetFloat("speed", 1);
    }

    public bool Ground(){
        return Physics2D.OverlapCircle(footPosition.position, 0.1f, groundLayer);
    }
}
