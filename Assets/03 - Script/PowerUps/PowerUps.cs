using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps = new GameObject[1];
    private int currentPowerUp = 1;

    public void Execute(){
        if(currentPowerUp <= powerUps.Length){
            powerUps[currentPowerUp - 1].SendMessage("Action");
        }else{
            currentPowerUp = 1;
        }
    }
}