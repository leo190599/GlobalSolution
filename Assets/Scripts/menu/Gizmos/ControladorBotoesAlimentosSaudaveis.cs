using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBotoesAlimentosSaudaveis : MonoBehaviour
{
    public InformacoesPlayer informacoesPlayer;
    public Button botaoBatataDoce;
    public Button botaoCoxaDeFrango;
    public Button botaoAbacate;
    public Button botaoLaranja;
    public Button botaoMilho;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(informacoesPlayer.getBatataDoce)
        {
            botaoBatataDoce.interactable=false;
        }
        else
        {
            botaoBatataDoce.interactable=true;
        }
        
        if(informacoesPlayer.getCoxaDeFrango)
        {
            botaoCoxaDeFrango.interactable=false;
        }
        else
        {
            botaoCoxaDeFrango.interactable=true;
        }
        
        if(informacoesPlayer.getAbacate)
        {
            botaoAbacate.interactable=false;
        }
        else
        {
            botaoAbacate.interactable=true;
        }

        if(informacoesPlayer.getLaranja)
        {
            botaoLaranja.interactable=false;
        }
        else
        {
            botaoLaranja.interactable=true;
        }

        if(informacoesPlayer.getMilho)
        {
            botaoMilho.interactable=false;
        }
        else
        {
            botaoMilho.interactable=true;
        }
    }
}
