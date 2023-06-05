using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MaquinaDeVendas : MonoBehaviour
{
    public GameObject gizmo;
    public ScriptPlayer player;
    public GameObject primeiroBotao;
    public EventSystem ev;
    public bool jaUsada=false;
    public InformacoesPlayer informacoesPlayer;
    public SpriteRenderer sprite;
    public Color corDesativada;
    public AudioSource emissor;
    public AudioClip clipCompra;
    // Start is called before the first frame update
    void Start()
    {
        gizmo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void comprarComida(int comida)
    {
        player.comprarComida(comida);
        jaUsada=true;
        gizmo.SetActive(false);
        sprite.color=corDesativada;
        emissor.loop=false;
        emissor.clip=clipCompra;
        emissor.Play();
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if(!jaUsada)
        {
            gizmo.SetActive(true);
            //ev.SetSelectedGameObject(primeiroBotao);
            player=c.gameObject.GetComponentInParent<ScriptPlayer>();
            if(player!=null)
            {
                player.maquinaDeVendas=this;
            }
            else
            {
                Debug.LogError("nao existePlayer");
            }
        }

    }
    void OnTriggerExit2D(Collider2D c)
    {
        if(!jaUsada)
        {
            player.maquinaDeVendas=null;
            player=null;
            gizmo.SetActive(false);
        }
    }
}
