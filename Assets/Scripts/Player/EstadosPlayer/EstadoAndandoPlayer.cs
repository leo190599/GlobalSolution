using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAndandoPlayer : EstadoAtivoBasePlayer
{
    public override void IniciarEstadoPlayer(ScriptPlayer player)
    {
        base.IniciarEstadoPlayer(player);
         player.trocarEstadoAnimator(ScriptPlayer.estadoAnimator.andando);
        player.emissor.clip=player.passos;
        player.emissor.loop=true;
        player.emissor.Play();


         player.GetRigidbody2D.velocity=new Vector2(Input.GetAxis(player.GetMapeadorDeBotoes.GetEixoDeMovimentoHorizontal)*(player.GetVelocidadeDeMovimento+
         (player.GetInformacoesPlayer.getBatataDoce ? player.GetInformacoesPlayer.bonusVelBatataDoce:0)+(player.GetInformacoesPlayer.getRefrigerante?player.GetInformacoesPlayer.bonusVelBatataDoce:0))
         ,player.GetRigidbody2D.velocity.y);
        player.GetRigidbody2D.sharedMaterial=player.GetMaterialFisicoAndando;
    }
    public override void AtualizarEstado()
    {
        base.AtualizarEstado();
        if(Input.GetAxisRaw(player.GetMapeadorDeBotoes.GetEixoDeMovimentoHorizontal)!=0)
        {
            player.RodarPersonagem(Mathf.Sign(Input.GetAxisRaw(player.GetMapeadorDeBotoes.GetEixoDeMovimentoHorizontal))>0);
             player.GetRigidbody2D.velocity=new Vector2(Input.GetAxis(player.GetMapeadorDeBotoes.GetEixoDeMovimentoHorizontal)*(player.GetVelocidadeDeMovimento+
         (player.GetInformacoesPlayer.getBatataDoce ? player.GetInformacoesPlayer.bonusVelBatataDoce:0)+(player.GetInformacoesPlayer.getRefrigerante?player.GetInformacoesPlayer.bonusVelBatataDoce:0))
         ,player.GetRigidbody2D.velocity.y);
        }
        else
        {
            player.TrocaEstadoPlayer(new EstadoIdlePlayer());
            return;
        }
        if(Input.GetKeyDown(player.GetMapeadorDeBotoes.GetBotaoPulo))
        {
           player.GetRigidbody2D.AddForce(new Vector2(0,player.GetForcaPulo+(player.GetInformacoesPlayer.getMilho?player.GetInformacoesPlayer.forcaPuloMilho:0)+
           (player.GetInformacoesPlayer.getBolo?player.GetInformacoesPlayer.bonusPuloBolo:0)),ForceMode2D.Impulse);
            player.TrocaEstadoPlayer(new EstadoPuloPlayer());
            return;
        }
        if(Input.GetKeyDown(player.GetMapeadorDeBotoes.GetBotaoAtque))
        {
            player.TrocaEstadoPlayer(new EstadoAtaquePlayer());
        }

       // Debug.Log(player.GetRigidbody2D.velocity.x);
    }

    public override void FinalizarEstado()
    {
        base.FinalizarEstado();
        player.trocarEstadoAnimator(ScriptPlayer.estadoAnimator.idle);
        player.emissor.Stop();
    }
}
