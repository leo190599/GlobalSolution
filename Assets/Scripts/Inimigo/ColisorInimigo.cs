using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorInimigo : MonoBehaviour
{
    public InimigoScript inimigoControlado;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D c)
    {
        ScriptPlayer player=c.GetComponentInParent<ScriptPlayer>();
        inimigoControlado.perseguir(player);
    }
    void OnTriggerExit2D(Collider2D c)
    {
        inimigoControlado.pararPerseguicao();
    }
}
