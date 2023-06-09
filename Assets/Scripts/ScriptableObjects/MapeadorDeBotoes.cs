using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NovoMapeadorDeBotoes",menuName ="ScriptableObjectsCustomizados/MapeadorDeBotoes")]
public class MapeadorDeBotoes : ScriptableObject
{
    [SerializeField]
    private string eixoDeMovimentoHorizontal="Horizontal";
   [SerializeField]
   private KeyCode botaoPulo=KeyCode.Space;
   [SerializeField]
   private KeyCode botaoPause=KeyCode.Escape;
   [SerializeField]
   private KeyCode botaoAtaque=KeyCode.Mouse0;
   public KeyCode botaoDeInterassao=KeyCode.UpArrow;

   public string GetEixoDeMovimentoHorizontal=>eixoDeMovimentoHorizontal;
   public KeyCode GetBotaoPulo=>botaoPulo;
   public KeyCode GetBotaoPause=>botaoPause;
   public KeyCode GetBotaoAtque=>botaoAtaque;
}
