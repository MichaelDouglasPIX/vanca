using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float jumpForce;
    [Header("Attributes")]
     public Animator animator;
     public Rigidbody2D rb;

    public void Action(){
    animator.SetTrigger("jump");
    rb.velocity = rb.transform.up * jumpForce;
    }
}
