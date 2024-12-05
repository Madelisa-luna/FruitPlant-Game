using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJuego : MonoBehaviour
{
    public GameObject FinDeJuegoPa;

    public void FinalDeJuego()
    {
        Time.timeScale = 0;
        FinDeJuegoPa.SetActive(true);
    }

    public void RegresarMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main-Menu-Example");
    }
}
