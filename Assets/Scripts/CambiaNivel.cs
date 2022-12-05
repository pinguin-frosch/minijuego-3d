using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiaNivel : MonoBehaviour
{
    // Start is called before the first frame update
    public string NombreEscena;
    private void OnTriggerEnter(Collider other) {
    if(other.tag == "banderaroja")
    {
        SceneManager.LoadScene(NombreEscena);
    }        
    }
}
