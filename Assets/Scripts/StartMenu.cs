using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame() // tutaj musimy typ metody ustawiæ na public, ¿eby button dzia³a³ i by³ w stanie oddzia³owywaæ na inne sceny
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
