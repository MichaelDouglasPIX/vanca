using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUnty : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private bool falling;
    private Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {

        if(Input.GetMouseButton(0)){
            Walk();
        }
    }
    private void Walk(){
        transform.position += new Vector3(1,0,0) * Time.deltaTime * moveSpeed;
    }
}
