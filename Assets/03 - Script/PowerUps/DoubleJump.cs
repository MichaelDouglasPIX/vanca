using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float jumpForce;
    [Header("Attributes")]
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    public void Action(){//Comportamento do PowerUp
    animator.SetTrigger("jump");
    rb.velocity = rb.transform.up * jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D other) {//Preenchimento dos Atibutos, Instancia salva na lista de powerups do Player
        if(other.tag == "Player"){
            rb = other.GetComponent<Rigidbody2D>();
            animator = other.GetComponent<Animator>();
            sprite.enabled = false;
            other.SendMessage("AddPowerUp", gameObject);
        }
    }
}
