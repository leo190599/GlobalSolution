using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBarraVidaPersonagem : MonoBehaviour
{
    [SerializeField]
    private ControladorBarraDeProgresso controladorBarraDeProgresso;
    [SerializeField]
    private InformacoesPlayer informacoesPlayer;

    public RectTransform transformada;


    public bool incrementado=false;
    public int widthBase=400;
    public int widthIncrementada=600;
    // Start is called before the first frame update
    void Start()
    {
        controladorBarraDeProgresso=GetComponent<ControladorBarraDeProgresso>();
        if(controladorBarraDeProgresso==null)
        {
            Debug.LogError("Coloque esse componente em um objeto com um controlador de barra de progresso");
        }
        else
        {
            AlterarProgresso();
        }
    }

    public void AlterarProgresso()
    {
        controladorBarraDeProgresso.AlterarProgresso(informacoesPlayer.GetPorcentagemDeVida);
    }
    public void AlterarProgressoAbacate()
    {
        transformada.localScale=new Vector2(transformada.localScale.x*(informacoesPlayer.vidaIncrementada/informacoesPlayer.vidaBase),transformada.localScale.y);
        incrementado=true;
        informacoesPlayer.EncherVida();
        controladorBarraDeProgresso.AlterarProgresso(informacoesPlayer.GetPorcentagemDeVida);
    }
    void OnEnable()
    {
        if(controladorBarraDeProgresso!=null)
        {
            AlterarProgresso();
        }
        informacoesPlayer.EventosLevarDano+=AlterarProgresso;
        informacoesPlayer.EventosCura+=AlterarProgresso;
        
        informacoesPlayer.EventosAbacte+=AlterarProgressoAbacate;
    }
    void OnDisable()
    {
        informacoesPlayer.EventosLevarDano-=AlterarProgresso;
        informacoesPlayer.EventosCura-=AlterarProgresso;

        informacoesPlayer.EventosAbacte-=AlterarProgressoAbacate;
    }
}
