using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // musimy to doda�, aby m�c operowa� scenami

public class Finish : MonoBehaviour
{
    private AudioSource finishSound; // w tym wypadku nie u�ywamy sertilize i mo�emy skorzysta� z metody GetComponent, poniewa� dla tego obiektu mamy tylko jeden d�wi�k.

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
            Invoke("CompleteLevel", 2f); // Ta opcja daje mo�liwo�� delayowania wykonania jakiej� funkcji. Jako parametry podajemy - metode, kt�rej delay ma si� dotyczy� + czas delay-a w sekundach
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // ta linijka kodu m�wi mened�erowi scen aby za�adowa� now� scen�, ale tym razem nie robimy reload, jak dla PlayLife
                                                                              // tylko m�wimy, aby mened�er wzia� aktywn� scen� wraz z indexem (index wida� w Build Settings) i do tej warto�ci dodajemy 1, aby kolejna scena si� za�adowa�a.
    }
}
