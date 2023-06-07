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

    public Animator anim;

    public float vel;
    public Collider2D areaDePatrulha;
    public bool olhandoParaADireita;

    public float vidaMaxima=10;
    public float vida;
    public float ataque=10;
    public float defesa=5;

    public float distanciaParaAtaque=.5f;
    public float novaPosicaoX;
    public estadoInimigo estado;
    public ScriptPlayer alvo;
    public Vector2 centroColisaoHitEmRelacaoAonInimigo;
    public Vector2 dimensoesColisaoHit;
    public LayerMask layerAtaque;
    public SpriteRenderer sprite;
    public AudioSource somHit;
    // Start is called before the first frame update
    void Start()
    {
        vida=vidaMaxima;
        olhandoParaADireita=Random.Range(0,10)>5 ? true:false;
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
                    if(alvo!=null)
                    {
                        novaPosicaoX=transform.position.x+Mathf.Sign(alvo.gameObject.transform.position.x-transform.position.x)*vel*Time.deltaTime;

                        
                        sprite.flipX=novaPosicaoX>transform.position.x?true:false;
                        olhandoParaADireita=novaPosicaoX>transform.position.x?true:false;

                        novaPosicaoX= Mathf.Clamp(novaPosicaoX,
                        areaDePatrulha.bounds.min.x,
                        areaDePatrulha.bounds.max.x);

                        transform.position=new Vector2(novaPosicaoX,transform.position.y);

                        if(Mathf.Abs(alvo.transform.position.x-transform.position.x)<distanciaParaAtaque)
                        {
                            estado=estadoInimigo.ataque;
                        }
                    }
                    else
                    {
                        estado=estadoInimigo.patrulhando;
                    }
            break;
            case estadoInimigo.ataque:
                if(alvo!=null)
                {
                    anim.SetBool("Atacando",true);
                }
                else
                {
                    estado=estadoInimigo.patrulhando;
                }
            break;
        }
    }

    void OnDrawGizmosSelected()
    {
       // Gizmos.DrawLine(col.bounds.center,new Vector3(col.bounds.center.x,col.bounds.min.y-distanciaChecagemPulo,col.bounds.min.z));
       if(olhandoParaADireita)
       {
            Gizmos.DrawWireCube(new Vector2(transform.position.x+centroColisaoHitEmRelacaoAonInimigo.x,transform.position.y+centroColisaoHitEmRelacaoAonInimigo.y),dimensoesColisaoHit);
       }
       else
       {
            Gizmos.DrawWireCube(new Vector2(transform.position.x-centroColisaoHitEmRelacaoAonInimigo.x,transform.position.y+centroColisaoHitEmRelacaoAonInimigo.y),dimensoesColisaoHit);
       }
    }
    public void Atacar()
    {
        estado=estadoInimigo.perseguindo;
        Collider2D atacado;
        //Debug.Log("a");
        if(olhandoParaADireita)
        {
            atacado= Physics2D.OverlapBox(new Vector2(transform.position.x+centroColisaoHitEmRelacaoAonInimigo.x,transform.position.y+centroColisaoHitEmRelacaoAonInimigo.y),dimensoesColisaoHit,0,layerAtaque);
        }
        else
        {
            atacado= Physics2D.OverlapBox(new Vector2(transform.position.x-centroColisaoHitEmRelacaoAonInimigo.x,transform.position.y+centroColisaoHitEmRelacaoAonInimigo.y),dimensoesColisaoHit,0,layerAtaque);
        }
        
        if(atacado!=null)
        {
             if(atacado.GetComponentInParent<ScriptPlayer>()!=null)
             {
                atacado.GetComponentInParent<ScriptPlayer>().ReceberDano(ataque);
             }
        }
        anim.SetBool("Atacando",false);
    }
    public void ReceberDano(float quantidadeDeDano)
    {
        anim.SetBool("RecebeuDano",true);
        vida-=(quantidadeDeDano-defesa);
        somHit.Play();
        if(vida<=0)
        {
            EventoChefe();
            Destroy(transform.parent.gameObject);
        }
    }

    public virtual void EventoChefe()
    {

    }

    public void pararRecebimentoDeDanoAnim()
    {
        anim.SetBool("RecebeuDano",false);
    }

    public void perseguir(ScriptPlayer player)
    {
        alvo=player;
        Debug.Log(alvo);
        estado=estadoInimigo.perseguindo;
    }
    public void pararPerseguicao()
    {
        alvo = null;
        estado=estadoInimigo.patrulhando;
        
    }
}
