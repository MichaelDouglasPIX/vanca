using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUps = new List<GameObject>();
    private int currentPowerUp = 1;

    public void Execute(){//Executa o PowerUp de acordo com o contador
        if(currentPowerUp <= powerUps.Count){
            if(powerUps[currentPowerUp - 1] != null){
                GameObject teste = powerUps[currentPowerUp - 1];
                teste.GetComponent<DoubleJump>().Action();
                ++currentPowerUp;
            }
        }
    }

    public void Reset(){//Reseta contador de PowerUps
        currentPowerUp = 1;
    }

    public void AddPowerUp(GameObject obj){//Adiciona um PowerUp novo a lista
        powerUps.Add(obj);
    }
}