using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMensageiroAnimacaoPlayer : MonoBehaviour
{
    public ScriptPlayer scriptPlayer;
    // Start is called before the first frame update
    public void AtivarEventoInicioAnimacao()
    {
        scriptPlayer.AtivarEventoInicioAnimacao();
    }
    public void AtivarEventoAnimacao()
    {
        scriptPlayer.AtivarEventoAnimacao();
    }
    public void AtivarEventoFinalAnimacao()
    {
        scriptPlayer.AtivarEventoFinalAnimacao();
    }
}
