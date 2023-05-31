using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBotaoBatataDoce : ControladorDeBotaoAlimento
{
    // Start is called before the first frame update
    void OnEnable()
    {
        if(informacoesPlayer.getBatataDoce)
        {
            b.interactable=false;
        }
        else
        {
            b.interactable=true;
        }
    }
}
