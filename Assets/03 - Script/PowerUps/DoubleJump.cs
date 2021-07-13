using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : PowerUp
{
    [Header("Movement")]
    [SerializeField] private float jumpForce;

    public override void Action(){//Comportamento especifico do PowerUp
    animator.SetTrigger("jump");
    rb.velocity = rb.transform.up * jumpForce;
    }
}
