using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptPlayer : MonoBehaviour
{
    [Header("Parametros Design")]
    [SerializeField]
    private float velocidadeDeMovimento=5f;
    [SerializeField]
    private float forcaPulo=10;
    [SerializeField]
    private bool olhandoParaDireita=true;

    [SerializeField]
    [Range(0f,1f)]
    private float perdaDeMovimentoNoAr=0f;
    [SerializeField]
    private float vidaCuradaPorColisaoParticula=1;
   
    public Vector2 centroColisaoHitEmRelacaoAoPlayer;
    public Vector2 dimensoesColisaoHit;
    public AudioClip passos;

    [Header("Parametros Debug")]
    [SerializeField]
    private InformacoesPlayer informacoesPlayer;
    [SerializeField]
    private float distanciaChecagemPulo=1;
    [SerializeField]

    private SpriteRenderer sprite;
    public LayerMask layerAtaque;
    private List<RaycastHit2D>raycastsPulo;
    public AudioSource emissorRecebeuDano;
    public AudioSource emissor;

    [Header("Scriptable objects")]
    [SerializeField]
    private ControladorDeCena controldadorDeCenaPlayer;
    [SerializeField]
    private MapeadorDeBotoes mapeadorDeBotoes;
    private EstadoBasePlayer estadoPlayerAtual;
    
    [Header("Materiais Fisicos")]
    [SerializeField]
    private PhysicsMaterial2D materialFisicoParado;
    [SerializeField]
    private PhysicsMaterial2D materialFisicoAndando;

    [Header("Componentes fisicos")]
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private CapsuleCollider2D col;

    public Animator anim;
    public MaquinaDeVendas maquinaDeVendas;

    public enum estadoAnimator
    {
        idle=0,
        andando=1,
        hit=2,
        caindo=3
    }

    void Awake()
    {
        informacoesPlayer.ZerarAlimentos();
    }
    // Start is called before the first frame update
    void Start()
    {
        controldadorDeCenaPlayer.TrocarEstadoAtual(ControladorDeCena.TipoEstadoCena.jogando);
        informacoesPlayer.EncherVida();
        raycastsPulo=new List<RaycastHit2D>();
        rb=GetComponent<Rigidbody2D>();
        col=GetComponent<CapsuleCollider2D>();

        informacoesPlayer.reiniciarSlots();

        estadoPlayerAtual=new EstadoIdlePlayer();

        estadoPlayerAtual.IniciarEstadoPlayer(this);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(controldadorDeCenaPlayer.getEstadoCena==ControladorDeCena.TipoEstadoCena.jogando)
        {
            estadoPlayerAtual.AtualizarEstado();
            if(Input.GetKeyDown(mapeadorDeBotoes.GetBotaoPause))
            {
                controldadorDeCenaPlayer.TrocarEstadoAtual(ControladorDeCena.TipoEstadoCena.pausado);
            }
        }
        else if(controldadorDeCenaPlayer.getEstadoCena==ControladorDeCena.TipoEstadoCena.pausado)
        {
            if(Input.GetKeyDown(mapeadorDeBotoes.GetBotaoPause))
            {
                controldadorDeCenaPlayer.TrocarEstadoAtual(ControladorDeCena.TipoEstadoCena.jogando);
            }
        }
        else if(controldadorDeCenaPlayer.getEstadoCena==ControladorDeCena.TipoEstadoCena.morreu)
        {
            //if(Input.GetKeyDown(mapeadorDeBotoes.GetBotaoPause))
            //{
              //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //}
        }
      
    }

    void FixedUpdate()
    {   if(controldadorDeCenaPlayer.getEstadoCena==ControladorDeCena.TipoEstadoCena.jogando)
        {
            estadoPlayerAtual.AtualizarEstadoFixado();
            
            
            if(estadoPlayerAtual is EstadoAtivoBasePlayer && !(estadoPlayerAtual is EstadoNoArBasePlayer))
            {
                rb.Cast(Vector2.down,raycastsPulo,distanciaChecagemPulo);
                if(raycastsPulo.Count!=0)
                {
                    foreach(RaycastHit2D r in raycastsPulo)
                    {
                        if(r.collider.tag!="Player")
                        {
                            raycastsPulo.Clear();
                            return;
                        }
                    }
                    TrocaEstadoPlayer(new EstadoPuloPlayer());
                }
                else
                {
                    TrocaEstadoPlayer(new EstadoPuloPlayer());
                }
                raycastsPulo.Clear();
            }
        }
    }
    void OnDrawGizmosSelected()
    {
       // Gizmos.DrawLine(col.bounds.center,new Vector3(col.bounds.center.x,col.bounds.min.y-distanciaChecagemPulo,col.bounds.min.z));
       if(olhandoParaDireita)
       {
            Gizmos.DrawWireCube(new Vector2(transform.position.x+centroColisaoHitEmRelacaoAoPlayer.x,transform.position.y+centroColisaoHitEmRelacaoAoPlayer.y),dimensoesColisaoHit);
       }
       else
       {
            Gizmos.DrawWireCube(new Vector2(transform.position.x-centroColisaoHitEmRelacaoAoPlayer.x,transform.position.y+centroColisaoHitEmRelacaoAoPlayer.y),dimensoesColisaoHit);
       }
    }

    public void Atacar()
    {
        
         Collider2D atacado;
        if(olhandoParaDireita)
        {
            atacado= Physics2D.OverlapBox(new Vector2(transform.position.x+centroColisaoHitEmRelacaoAoPlayer.x,transform.position.y+centroColisaoHitEmRelacaoAoPlayer.y),dimensoesColisaoHit,0,layerAtaque);
            Debug.Log("a");
        }
        else
        {
            atacado= Physics2D.OverlapBox(new Vector2(transform.position.x-centroColisaoHitEmRelacaoAoPlayer.x,transform.position.y+centroColisaoHitEmRelacaoAoPlayer.y),dimensoesColisaoHit,0,layerAtaque);
        }
        if(atacado!=null)
        {
            
             if(atacado.GetComponentInParent<InimigoScript>()!=null)
             {
                atacado.GetComponentInParent<InimigoScript>().ReceberDano(informacoesPlayer.forca);
             }
        }
    }

    public void Despausar()
    {
        controldadorDeCenaPlayer.TrocarEstadoAtual(ControladorDeCena.TipoEstadoCena.jogando);
    }
    public void ReiniciarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void VoltarAOMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void trocarEstadoAnimator(estadoAnimator novoEstado)
    {
        int proximoEstado=0;
        switch(novoEstado)
        {
            case estadoAnimator.idle:
                proximoEstado=0;
            break;
            case estadoAnimator.andando:
                proximoEstado=1;
            break;
            case estadoAnimator.hit:
                proximoEstado=2;
            break;
            case estadoAnimator.caindo:
                proximoEstado=3;
            break;
        }
        anim.SetInteger("Estado",proximoEstado);
    }
    void OnEnable()
    {
        informacoesPlayer.EventosMorte+=Morrer;
    }
    void OnDisable()
    {
        informacoesPlayer.EventosMorte-=Morrer;
    }

    public void comprarComida(int comida)
    {
        if(maquinaDeVendas!=null)
        {
            switch(comida)
            {
                case 0:
                    informacoesPlayer.setBatataDoce(true);
                break;
                case 1:
                    informacoesPlayer.setCoxaDeFrango(true);
                break;
                case 2:
                    informacoesPlayer.setAbacte(true);
                break;
                case 3:
                    informacoesPlayer.setLaranja(true);
                break;
                case 4:
                    informacoesPlayer.setMilho(true);
                break;
                case 5:
                    informacoesPlayer.setRefrigerante(true);
                break;
                case 6:
                    informacoesPlayer.setHamburger(true);
                break;
                case 7:
                    informacoesPlayer.setSalgadinho(true);
                break;
                case 8:
                    informacoesPlayer.setBolo(true);
                break;
            }
           // Debug.Log(comida);
        }
    }

    public void AtivarEventoInicioAnimacao()
    {
        estadoPlayerAtual.EventoInicioAnimacao();
    }
    public void AtivarEventoAnimacao()
    {
        estadoPlayerAtual.EventoAnimacao();
    }
    public void AtivarEventoFinalAnimacao()
    {
        estadoPlayerAtual.EventoFinalAnimacao();
    }
    public void pararRecebimentoDeDanoAnim()
    {
        anim.SetBool("RecebeuDano",false);   
    }

    public void ReceberDano(float quantidadeDeDano)
    {
        anim.SetBool("RecebeuDano",true);
        emissorRecebeuDano.Play();
        informacoesPlayer.ReceberDano(quantidadeDeDano);
    }
    public void Curar(float quantidadeDeCura)
    {
        informacoesPlayer.Curar(quantidadeDeCura);
    }

    public void Morrer()
    {
        rb.sharedMaterial=materialFisicoParado;
        rb.velocity=new Vector2(0,rb.velocity.y);
        emissor.Stop();
        controldadorDeCenaPlayer.TrocarEstadoAtual(ControladorDeCena.TipoEstadoCena.morreu);
    }

    public void TrocaEstadoPlayer(EstadoBasePlayer novoEstado)
    {
        estadoPlayerAtual.FinalizarEstado();
        estadoPlayerAtual=novoEstado;
        estadoPlayerAtual.IniciarEstadoPlayer(this);
    }
    public void RodarPersonagem(bool olhandoParaDireita)
    {
        if(olhandoParaDireita)
        {
            sprite.flipX=false;
            this.olhandoParaDireita=true;
        }
        else
        {
            sprite.flipX=true;
            this.olhandoParaDireita=false;
        }
    }
   
    public InformacoesPlayer GetInformacoesPlayer=>informacoesPlayer;
    public PhysicsMaterial2D GetMaterialFisicoParado=> materialFisicoParado;
    public PhysicsMaterial2D GetMaterialFisicoAndando=>materialFisicoAndando;
    public MapeadorDeBotoes GetMapeadorDeBotoes=>mapeadorDeBotoes;
    public Rigidbody2D GetRigidbody2D=>rb;
    public CapsuleCollider2D GetCapsuleCollider2D=>col;
    public float GetVelocidadeDeMovimento=>velocidadeDeMovimento;
    public float GetForcaPulo=>forcaPulo;
    public bool GetOlhandoParaDireita=>olhandoParaDireita;
    public float GetPerdaDeMovimentoNoAr=>perdaDeMovimentoNoAr;
    public List<RaycastHit2D> GetRaycastsPulo=>raycastsPulo;
    public float GetDistanciaChecagemPulo=>distanciaChecagemPulo;
    public float GetVidaCuradaPorColisaoParticula=>vidaCuradaPorColisaoParticula;
    public SpriteRenderer getSpriteRenderer=>sprite;
}
