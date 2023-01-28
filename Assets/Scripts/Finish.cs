using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // musimy to dodaæ, aby móc operowaæ scenami

public class Finish : MonoBehaviour
{
    private AudioSource finishSound; // w tym wypadku nie u¿ywamy sertilize i mo¿emy skorzystaæ z metody GetComponent, poniewa¿ dla tego obiektu mamy tylko jeden dŸwiêk.

    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f); // Ta opcja daje mo¿liwoœæ delayowania wykonania jakiejœ funkcji. Jako parametry podajemy - metode, której delay ma siê dotyczyæ + czas delay-a w sekundach
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // ta linijka kodu mówi mened¿erowi scen aby za³adowa³ now¹ scenê, ale tym razem nie robimy reload, jak dla PlayLife
                                                                              // tylko mówimy, aby mened¿er wzia³ aktywn¹ scenê wraz z indexem (index widaæ w Build Settings) i do tej wartoœci dodajemy 1, aby kolejna scena siê za³adowa³a.
    }
}
