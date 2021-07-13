using System.Collections.Generic;
using UnityEngine;

/*
 * Classe abstrata da qual todos os PowerUps devem derivar
 */

public abstract class PowerUp : MonoBehaviour
{
   [Header("Attributes")]
   [SerializeField] protected SpriteRenderer sprite;
   [SerializeField] protected Rigidbody2D rb;
   [SerializeField] protected Animator animator;

   public abstract void Action();//Método obrigatório para comportamento do PowerUp

    public void OnTriggerEnter2D(Collider2D other) {//Preenchimento dos Atibutos, Instancia salva na lista de powerups do Player
        if(other.tag == "Player"){
            rb = other.GetComponent<Rigidbody2D>();
            animator = other.GetComponent<Animator>();
            sprite.enabled = false;
            other.SendMessage("AddPowerUp", gameObject);
        }
    }
}
