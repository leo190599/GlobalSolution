using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoScript : MonoBehaviour
{
    public enum estadoInimigo
    {
        patrulhando=0,
        perseguindo=1,
        ataque=2
    }
    public float vel;
    public Collider2D areaDePatrulha;
    public bool olhandoParaADireita;

    public static float vidaMaxima=50;
    public float vida;
    public static float ataque=10;
    public static float defesa=5;

    public float distanciaParaAtaque=.5f;
    public float novaPosicaoX;
    public estadoInimigo estado;
    public ScriptPlayer alvo;
    public SpriteRenderer sprite;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        vida=vidaMaxima;
       // olhandoParaADireita=Random.Range(0,10)>5 ? true:false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(estado)
        { 
            case estadoInimigo.patrulhando:
                if(olhandoParaADireita)
                {
                    sprite.flipX=true;
                    novaPosicaoX=transform.position.x+vel*Time.deltaTime;

                    if(novaPosicaoX>areaDePatrulha.bounds.max.x)
                    {
                        olhandoParaADireita=false;
                    }

                    novaPosicaoX= Mathf.Clamp(novaPosicaoX,
                    areaDePatrulha.bounds.min.x,
                    areaDePatrulha.bounds.max.x);

                    transform.position=new Vector2(novaPosicaoX,transform.position.y);

                    
                }
                else
                {
                    sprite.flipX=false;
                    novaPosicaoX=transform.position.x-vel*Time.deltaTime;

                    if(novaPosicaoX<areaDePatrulha.bounds.min.x)
                    {
                        olhandoParaADireita=true;
                    }

                    novaPosicaoX= Mathf.Clamp(novaPosicaoX,
                    areaDePatrulha.bounds.min.x,
                    areaDePatrulha.bounds.max.x);

                    transform.position=new Vector2(novaPosicaoX,transform.position.y);
                }
            break;

            case estadoInimigo.perseguindo:

                    novaPosicaoX=transform.position.x+Mathf.Sign(alvo.gameObject.transform.position.x-transform.position.x)*vel*Time.deltaTime;

                    sprite.flipX=novaPosicaoX>transform.position.x?true:false;

                    novaPosicaoX= Mathf.Clamp(novaPosicaoX,
                    areaDePatrulha.bounds.min.x,
                    areaDePatrulha.bounds.max.x);

                    transform.position=new Vector2(novaPosicaoX,transform.position.y);

                    if(Mathf.Abs(alvo.transform.position.x-transform.position.x)<distanciaParaAtaque)
                    {
                       estado=estadoInimigo.ataque;
                    }
            break;
            case estadoInimigo.ataque:

            break;
        }
    }
    public void perseguir(ScriptPlayer player)
    {
        alvo=player;
        Debug.Log(alvo);
        estado=estadoInimigo.perseguindo;
    }
    public void pararPerseguicao()
    {
        estado=estadoInimigo.patrulhando;
    }
}
