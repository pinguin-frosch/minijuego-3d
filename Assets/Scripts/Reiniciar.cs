using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Reiniciar : MonoBehaviour
{
    private Scene escena;

    void Start()
    {
        escena = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(escena.name);
        }
    }
}
