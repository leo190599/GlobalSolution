using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBotoesAlimentosSaudaveis : MonoBehaviour
{
    public InformacoesPlayer informacoesPlayer;
    public Button botaoBatataDoce;
    public GameObject labelBatataDoce;
    public Button botaoCoxaDeFrango;
    public GameObject labelCoxaDeFrango;
    public Button botaoAbacate;
    public GameObject labelAbacate;
    public Button botaoLaranja;
    public GameObject labelLaranja;
    public Button botaoMilho;
    public GameObject labelMilho;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(informacoesPlayer.getBatataDoce)
        {
            botaoBatataDoce.interactable=false;
            labelBatataDoce.SetActive(false);
        }
        else
        {
            botaoBatataDoce.interactable=true;
            labelBatataDoce.SetActive(true);
        }
        
        if(informacoesPlayer.getCoxaDeFrango)
        {
            botaoCoxaDeFrango.interactable=false;
            labelCoxaDeFrango.SetActive(false);
        }
        else
        {
            botaoCoxaDeFrango.interactable=true;
            labelCoxaDeFrango.SetActive(true);
        }
        
        if(informacoesPlayer.getAbacate)
        {
            botaoAbacate.interactable=false;
            labelAbacate.SetActive(false);

        }
        else
        {
            botaoAbacate.interactable=true;
            labelAbacate.SetActive(true);
        }

        if(informacoesPlayer.getLaranja)
        {
            botaoLaranja.interactable=false;
            labelLaranja.SetActive(false);
        }
        else
        {
            botaoLaranja.interactable=true;
            labelLaranja.SetActive(true);
        }

        if(informacoesPlayer.getMilho)
        {
            botaoMilho.interactable=false;
            labelMilho.SetActive(false);
        }
        else
        {
            botaoMilho.interactable=true;
            labelMilho.SetActive(true);
        }
    }
}
