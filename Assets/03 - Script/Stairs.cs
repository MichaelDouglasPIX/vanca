using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float jumpForce;
    Rigidbody2D rb;
    private bool collision;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !collision){         
            collision = true;
            rb = other.GetComponent<Rigidbody2D>();
            rb.transform.position = new Vector2 (transform.position.x, rb.transform.position.y);
            rb.isKinematic = true;
            other.GetComponent<PlayerMovement>().ladder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(collision){
        rb.isKinematic = false;
        other.GetComponent<PlayerMovement>().ladder = false;
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        this.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
