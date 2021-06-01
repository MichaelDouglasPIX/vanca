using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float jumpForce;
    [Header("Attributes")]
    [SerializeField] private Animator animator;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            animator.SetTrigger("jump");
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.velocity = rb.transform.up * jumpForce;
        }
    }
}
