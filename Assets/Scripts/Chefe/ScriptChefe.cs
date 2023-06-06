using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptChefe : InimigoScript
{
    public ControladorDeCena controladorDeCena;
    // Start is called before the first frame update
    public override void EventoChefe()
    {
        base.EventoChefe();
        controladorDeCena.TrocarEstadoAtual(ControladorDeCena.TipoEstadoCena.venceu);
    }

}
