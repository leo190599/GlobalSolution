using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAtaquePlayer : EstadoAtivoBasePlayer
{
    public override void IniciarEstadoPlayer(ScriptPlayer player)
    {
        base.IniciarEstadoPlayer(player);
        player.GetRigidbody2D.sharedMaterial=player.GetMaterialFisicoParado;
        player.GetRigidbody2D.velocity=new Vector2(0,player.GetRigidbody2D.velocity.y);
        player.trocarEstadoAnimator(ScriptPlayer.estadoAnimator.hit);
    }
    public override void EventoInicioAnimacao()
    {
        base.EventoInicioAnimacao();
    }
    public override void EventoAnimacao()
    {
        base.EventoAnimacao();
        Debug.Log("a");
    }

    public override void EventoFinalAnimacao()
    {
        base.EventoFinalAnimacao();
        player.TrocaEstadoPlayer(new EstadoIdlePlayer());
        player.trocarEstadoAnimator(ScriptPlayer.estadoAnimator.idle);
    }
}
