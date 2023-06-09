using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPuloPlayer : EstadoNoArBasePlayer
{
    public override void IniciarEstadoPlayer(ScriptPlayer player)
    {
        base.IniciarEstadoPlayer(player);
        //player.GetRigidbody2D.sharedMaterial=player.GetMaterialFisicoParado;
        player.trocarEstadoAnimator(ScriptPlayer.estadoAnimator.caindo);
    }
    public override void AtualizarEstadoFixado()
    {
        base.AtualizarEstadoFixado();
        if(Mathf.Abs(player.GetRigidbody2D.velocity.x+Mathf.Lerp(Input.GetAxis(player.GetMapeadorDeBotoes.GetEixoDeMovimentoHorizontal)*player.GetVelocidadeDeMovimento,0,player.GetPerdaDeMovimentoNoAr))<player.GetVelocidadeDeMovimento)
        {
           // Debug.Log("a");
            player.GetRigidbody2D.AddForce(new Vector2(
            Mathf.Lerp(Input.GetAxis(player.GetMapeadorDeBotoes.GetEixoDeMovimentoHorizontal)*player.GetVelocidadeDeMovimento,0,player.GetPerdaDeMovimentoNoAr),0));
        }
        player.GetRigidbody2D.Cast(Vector2.down,player.GetRaycastsPulo,player.GetDistanciaChecagemPulo);
        //Essa checagem é feita para garantir que a personagem não volte para o estaddo Idle antes de sair do chão
        if(player.GetRaycastsPulo.Count!=0 && player.GetRigidbody2D.velocity.y<=0)
        {
            foreach(RaycastHit2D r in player.GetRaycastsPulo)
            {
                if(r.collider.tag!="Player" && r.collider.tag!="ColiderFantasma" && r.collider.tag!="Inimigo")
                {
                    if(Input.GetAxisRaw(player.GetMapeadorDeBotoes.GetEixoDeMovimentoHorizontal)!=0)
                    {
                        player.TrocaEstadoPlayer(new EstadoAndandoPlayer());
                    }
                    else
                    {
                        player.TrocaEstadoPlayer(new EstadoIdlePlayer());
                    }
                    return;
                }
            }
        }
        player.GetRaycastsPulo.Clear();
    }
    public override void FinalizarEstado()
    {
        base.FinalizarEstado();
        player.trocarEstadoAnimator(ScriptPlayer.estadoAnimator.idle);
    }
}
