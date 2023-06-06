using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEventoInimigoAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public InimigoScript inimigoScript;
    public void ativarEfeitoDeAtaque()
    {
        inimigoScript.Atacar();
    }
    public void pararRecebimentoDeDanoAnim()
    {
        inimigoScript.pararRecebimentoDeDanoAnim();
    }
}
