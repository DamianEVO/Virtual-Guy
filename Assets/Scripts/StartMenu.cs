using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame() // tutaj musimy typ metody ustawi� na public, �eby button dzia�a� i by� w stanie oddzia�owywa� na inne sceny
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
