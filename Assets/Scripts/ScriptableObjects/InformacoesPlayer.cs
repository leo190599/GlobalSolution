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
    public float forcaPuloMilho=2;
    [SerializeField]
    private float vidaMaxima=100;
    [SerializeField]
    private float vidaAtual=100;
    [SerializeField]
    private bool refrigerante=false;
    [SerializeField]
    private bool hamburger=false;
    [SerializeField]
    private bool salgadinho=false;
    [SerializeField]
    private bool bolo=false;

    [Header("Status")]
    
    public float forcaBase=5;

    public float forcaCochaDeFrango=8;
    public float forca=5;
    public float defesaBase=5;
    public float defesaLaranja=8;
    public float defesa=5;



    [Header("Abacate")]
    public float vidaBase=100;
    public float vidaIncrementada=150;

    [Header("Inventario")]
    public int indexSlot=0;
    public int[] slots;

    public UnityAction EventosAtualizacaoSlots;

    public UnityAction EventosAbacte;
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
        //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        forca=forcaBase;
        defesa=defesaBase;
        vidaMaxima=vidaBase;

        laranja=false;
        milho=false;
        refrigerante=false;
        hamburger=false;
        salgadinho=false;
        bolo=false;
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
            if(novoValor)
            {
                forca=forcaCochaDeFrango;
            }
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
            if(novoValor && EventosAbacte!=null)
            {
                vidaMaxima=vidaIncrementada;
                EventosAbacte.Invoke();
            }
            indexSlot++;
        }
    }
    public void setLaranja(bool novoValor)
    {
         if(indexSlot<slots.Length)
        {
            laranja=novoValor;
            if(novoValor)
            {
                defesa=defesaLaranja;
            }
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
    public void setRefrigerante(bool novoValor)
    {
        if(indexSlot<slots.Length)
        {
            refrigerante=novoValor;
            slots[indexSlot]=5;
            EventosAtualizacaoSlots.Invoke();
            indexSlot++;
        }
    }
    public void setHamburger(bool novoValor)
    {
        if(indexSlot<slots.Length)
        {
            hamburger=novoValor;
            slots[indexSlot]=6;
            EventosAtualizacaoSlots.Invoke();
            indexSlot++;
        }   
    }
    public void setSalgadinho(bool novoValor)
    {
        if(indexSlot<slots.Length)
        {
            salgadinho=novoValor;
            slots[indexSlot]=7;
            EventosAtualizacaoSlots.Invoke();
            indexSlot++;
        }   
    }
    public void setBolo(bool novoValor)
    {
        if(indexSlot<slots.Length)
        {
            bolo=novoValor;
            slots[indexSlot]=8;
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
        public bool getRefrigerante=>refrigerante;
        public bool getHamburger=>hamburger;
        public bool getSalgadinho=>salgadinho;
        public bool getBolo=>bolo;
}
