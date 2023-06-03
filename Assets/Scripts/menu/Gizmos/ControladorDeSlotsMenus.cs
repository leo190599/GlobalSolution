using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControladorDeSlotsMenus : MonoBehaviour
{
    // Start is called before the first frame update
    public InformacoesPlayer informacoesPlayer;
    public Image[] slots;

    public Color[] cores;
    void OnEnable()
    {
        //Debug.Log("a");
        informacoesPlayer.EventosAtualizacaoSlots+=AtualizarSlots;
        AtualizarSlots();
    }
    void OnDisable()
    {
        //Debug.Log("b");
        informacoesPlayer.EventosAtualizacaoSlots-=AtualizarSlots;
    }
    public void AtualizarSlots()
    {
        for(int i=0;i<informacoesPlayer.slots.Length;i++)
        {
            if(!informacoesPlayer.slots.GetValue(i).Equals(-1))
            {
                slots[i].color=cores[informacoesPlayer.slots[i]];
                Debug.Log(informacoesPlayer.slots[i]);
            }
            else
            {
                slots[i].color=Color.black;
            }
        }
       // Debug.Log("a");
    }
}
