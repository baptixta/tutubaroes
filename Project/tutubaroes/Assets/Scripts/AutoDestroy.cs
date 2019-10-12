using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    float timeOutsideScreen = 0.0f;

    void Update ()
    {
        //Não ta sendo renderizado, então ta fora da tela
        if (GetComponent<MeshRenderer>().isVisible == false)
        {
            //Contando o tempo fora da tela
            timeOutsideScreen += Time.deltaTime;
        }
        else //Ta sendo renderizado, entao ta na tela
        {
            //Resetando tempo fora da tela
            timeOutsideScreen = 0.0f;
        }

        //Tempo fora da tela maior que 2, então se destroi
        if (timeOutsideScreen >= 2)
        {
            Destroy (gameObject);
        }
    }
}
