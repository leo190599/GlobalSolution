using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="NovasInformacoesPlayer",menuName ="ScriptableObjectsCustomizados/InformacoesPlayer")]
public class InformacoesPlayer : ScriptableObject
{
     [Header("Comidas")]
    [SerializeField]
    private bool batataDoce=false;
    public float bonusVelBatataDoce=2;
    [SerializeField]
    private bool coxaDeFrango=false;

    [SerializeField]
    private bool abacate=false;
    [SerializeField]
    private bool laranja=false;
    [SerializeField]
    private bool milho=false;
    [SerializeField]
    private float vidaMaxima=100;
    [SerializeField]
    private float vidaAtual=100;

    public UnityAction EventosLevarDano;
    public UnityAction EventosCura;
    public UnityAction EventosMorte;

    public float GetPorcentagemDeVida=>Mathf.Clamp(vidaAtual/vidaMaxima,0f,100f);
    public float GetVidaAtual=>Mathf.Clamp(vidaAtual,0,vidaMaxima);
    public float GetVidaMaxima=>vidaMaxima;

    public void setBatataDoce(bool novoValor)
    {
        batataDoce=novoValor;
    }

    public void EncherVida()
    {
        vidaAtual=vidaMaxima;
        if(EventosCura!=null)
        {
            EventosCura.Invoke();
        }
    }
    public void Curar(float quantidadeDeCura)
    {
        vidaAtual=Mathf.Clamp(vidaAtual+quantidadeDeCura,0,vidaMaxima);
        if(EventosCura!=null)
        {
            EventosCura.Invoke();
        }
    }
    public void ReceberDano(float quantidadeDeDano)
    {
        vidaAtual-=quantidadeDeDano;
        if(EventosLevarDano!=null)
            {
                EventosLevarDano.Invoke();
            }
        if(vidaAtual<=0 && EventosMorte!=null)
        {

            EventosMorte.Invoke();
        }
    }
        public bool getBatataDoce=>batataDoce;
        public bool getCoxaDeFrango=>coxaDeFrango;
        public bool getAbacate=>abacate;
        public bool getLaranja=>laranja;
        public bool getMilho=>milho;
}