using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUps = new List<GameObject>();
    [SerializeField] private Animator anim;
    private int currentPowerUp = 1;


    public void Execute(){//Executa o PowerUp de acordo com o contador
        if(currentPowerUp <= powerUps.Count){
            if(powerUps[currentPowerUp - 1] != null){
                GameObject teste = powerUps[currentPowerUp - 1];
                //teste.GetComponent<DoubleJump>().Action();
                teste.SendMessage("Action");
                SetPowerUpAnim(false);
                ++currentPowerUp;
                if(currentPowerUp > powerUps.Count){
                    SetAnim(false);
                }else{
                    SetPowerUpAnim(true);
                }
            }
        }
    }

    public void Reset(){//Reseta contador de PowerUps e animações
        currentPowerUp = 1;
        SetAnim(true);
        SetPowerUpAnim(true);
    }

    public void AddPowerUp(GameObject obj){//Adiciona um PowerUp novo a lista e animações
        powerUps.Add(obj);
        SetAnim(true);
        SetPowerUpAnim(true);
    }

    public void SetAnim(bool status){//Status das animações de PowerUps
        if(powerUps.Count > 0){
            anim.SetBool("powerUp", status);
        }
    }

    private void SetPowerUpAnim(bool status){//Animação referente ao PowerUp atual
        if(powerUps.Count > 0){
            anim.SetBool(powerUps[currentPowerUp - 1].tag, status);
        } 
    }
}