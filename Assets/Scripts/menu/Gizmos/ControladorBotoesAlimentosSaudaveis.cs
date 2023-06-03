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
    public Button botaoRefrigerante;
    public GameObject labelRefrigerante;
    public Button botaoHamburguer;
    public GameObject labelHamburger;
    public Button botaoSalgadinho;
    public GameObject labelSalgadinho;
    public Button botaoBolo;
    public GameObject labelBolo;
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
        if (informacoesPlayer.getRefrigerante)
        {
            botaoRefrigerante.interactable=false;
            labelLaranja.SetActive(false);
        }
        else
        {
            botaoRefrigerante.interactable=true;
            labelLaranja.SetActive(true);
        }
        if(informacoesPlayer.getHamburger)
        {
            botaoHamburguer.interactable=false;
            labelHamburger.SetActive(false);
        }
        else
        {
            botaoHamburguer.interactable=true;
            labelHamburger.SetActive(true);
        }
        if(informacoesPlayer.getSalgadinho)
        {
            botaoSalgadinho.interactable=false;
            labelSalgadinho.SetActive(false);
        }
        else
        {
            botaoSalgadinho.interactable=true;
            labelSalgadinho.SetActive(true);
        }
        if(informacoesPlayer.getBolo)
        {
            botaoBolo.interactable=false;
            labelBolo.SetActive(false);
        }
        else
        {
             botaoBolo.interactable=true;
            labelBolo.SetActive(true);
        }
    }
}
