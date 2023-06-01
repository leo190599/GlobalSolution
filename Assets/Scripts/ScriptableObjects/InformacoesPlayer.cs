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

    public int indexSlot=0;
    public int[] slots;

    public UnityAction EventosAtualizacaoSlots;
    public UnityAction EventosLevarDano;
    public UnityAction EventosCura;
    public UnityAction EventosMorte;

    void Awake()
    {
        slots=new int[5];
        for(int i=0; i<slots.Length;i++)
        {
            slots[i]=-1;
        }
        indexSlot=0;
    }

    public float GetPorcentagemDeVida=>Mathf.Clamp(vidaAtual/vidaMaxima,0f,100f);
    public float GetVidaAtual=>Mathf.Clamp(vidaAtual,0,vidaMaxima);
    public float GetVidaMaxima=>vidaMaxima;

    public void ZerarAlimentos()
    {
        batataDoce=false;
        coxaDeFrango=false;
        abacate=false;
        laranja=false;
        milho=false;
    }
    public void setBatataDoce(bool novoValor)
    {
        if(indexSlot<slots.Length)
        {
            batataDoce=novoValor;
            slots[indexSlot]=0;
            EventosAtualizacaoSlots.Invoke();
            indexSlot++;
        }
    }

    public void setCoxaDeFrango(bool novoValor)
    {   
        if(indexSlot<slots.Length)
        {
            coxaDeFrango=novoValor;
            slots[indexSlot]=1;
            EventosAtualizacaoSlots.Invoke();
            indexSlot++;
        }
    }
    public void setAbacte(bool novoValor)
    {
         if(indexSlot<slots.Length)
        {
            abacate=novoValor;
            slots[indexSlot]=2;
            EventosAtualizacaoSlots.Invoke();
            indexSlot++;
        }
    }
    public void setLaranja(bool novoValor)
    {
         if(indexSlot<slots.Length)
        {
            laranja=novoValor;
            slots[indexSlot]=3;
            EventosAtualizacaoSlots.Invoke();
            indexSlot++;
        }
    }
    public void setMilho(bool novoValor)
    {
         if(indexSlot<slots.Length)
        {
            milho=novoValor;
            slots[indexSlot]=4;
            EventosAtualizacaoSlots.Invoke();
            indexSlot++;
        }
    }

    public void reiniciarSlots()
    {
        for(int i=0; i<slots.Length;i++)
        {
            slots[i]=-1;
        }
        indexSlot=0;
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
