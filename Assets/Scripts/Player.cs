using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sR;
    public float forcaPulo;
    public PhysicsMaterial2D materialAndando;
    public PhysicsMaterial2D materialParado;
    public float velPersonagem=5;
    public EstadoPlayer estadoPlayer;
    public bool flipado=false;
    private List<RaycastHit2D> rH;
    [Header("Botoes")]
    public KeyCode botaoPular=KeyCode.Space;
    // Start is called before the first frame update

    public enum EstadoPlayer
    {
        Andando=0,
        Pulando=1,
        Parado=2,
        Atacano=3
    };
    void Start()
    {
        rH=new List<RaycastHit2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(estadoPlayer==EstadoPlayer.Andando)
       {
            if(Input.GetKeyDown(botaoPular))
            {
                if(ChecarChao())
                {
                    pular();
                }
            }
       }
       else if(estadoPlayer==EstadoPlayer.Parado)
       {
            if(Input.GetKeyDown(botaoPular))
            {
                if(ChecarChao())
                {
                    pular();
                }
            }
       }
       
    }

    void FixedUpdate()
    {
        if(estadoPlayer==EstadoPlayer.Andando)
        {
            rb.velocity=(new Vector2(Input.GetAxis("Horizontal")*velPersonagem,rb.velocity.y));
            if(Input.GetAxisRaw("Horizontal")>0)
            {
                flipado=false;
                sR.flipX=flipado;
            }
            else if(Input.GetAxisRaw("Horizontal")<0)
            {
                flipado=true;
                sR.flipX=flipado;
            }
            else
            {
                rb.sharedMaterial=materialParado;
                estadoPlayer=EstadoPlayer.Parado;                
            }

            if(!ChecarChao())
            {
                estadoPlayer=EstadoPlayer.Pulando;
            }
        }
        else if(estadoPlayer==EstadoPlayer.Parado)
        {
            if(Input.GetAxisRaw("Horizontal")!=0)
            {
                rb.sharedMaterial=materialAndando;
                estadoPlayer=EstadoPlayer.Andando;
            }

            if(!ChecarChao())
            {
                estadoPlayer=EstadoPlayer.Pulando;
            }
            else
            {
                rb.sharedMaterial=materialParado;
            }
        }
        else if(estadoPlayer==EstadoPlayer.Pulando)
        {
            if(ChecarChao())
            {
                estadoPlayer=EstadoPlayer.Parado;
            }
        }
    }

    public void pular()
    {
        rb.velocity=new Vector2(rb.velocity.x,forcaPulo);
        estadoPlayer=EstadoPlayer.Pulando;
    }
    public bool ChecarChao()
    {
        rb.Cast(new Vector2(0,-1),rH,.5f);
        foreach(RaycastHit2D r in rH)
        {
            if(r.collider.tag=="chao")
            {
                rH.Clear();
                return true;
            }
        }
        return false;
    }
}
