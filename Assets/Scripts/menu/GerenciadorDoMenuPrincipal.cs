using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerenciadorDoMenuPrincipal : MonoBehaviour
{
    [SerializeField]
    private GameObject[] sessoesDeMenu;
    [SerializeField]
    private int indexMenuAtivo=0;
  
    // Start is called before the first frame update
    void Start()
    {
        if(sessoesDeMenu.Length==0)
        {
            Debug.LogError("O vetor de menus deve conter ao menos um menu");
        }
        if(indexMenuAtivo>=sessoesDeMenu.Length)
        {
            Debug.LogError("Index de menu invalido");
        }   
        for(int i=0;i<sessoesDeMenu.Length;i++)
        {
            if(i==indexMenuAtivo)
            {
                sessoesDeMenu[i].SetActive(true);
            }
            else
            {
                sessoesDeMenu[i].SetActive(false);
            }
        }
    }
    public void TrocarMenu(int novoIndex)
    {
        if(novoIndex>=sessoesDeMenu.Length)
        {
            Debug.LogError("Index de menu invalido");
        }
        else
        {
            sessoesDeMenu[indexMenuAtivo].SetActive(false);
            indexMenuAtivo=novoIndex;
            sessoesDeMenu[indexMenuAtivo].SetActive(true);
        }
    }

    public void TrocarCena(string nomeDaNovaCena)
    {
        if(SceneManager.GetSceneByName(nomeDaNovaCena)!=null)
        {
            SceneManager.LoadScene(nomeDaNovaCena);
        }
        else
        {
            Debug.Log("Cena nao existe");
        }    
    }
    public void FecharJogo()
    {
        Application.Quit();
    }
}