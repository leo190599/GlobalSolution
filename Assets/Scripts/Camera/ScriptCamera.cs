using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private Vector3 offSet;
    private Vector3 novaTransformada;
    //Startis called before the first frame update
    void Start()
    {
        offSet=transform.position-player.transform.position;    
        novaTransformada=new Vector3();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        novaTransformada=player.transform.position+offSet;
        transform.position=novaTransformada;

    }
}