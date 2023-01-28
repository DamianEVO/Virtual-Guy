using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0;

    [SerializeField] private TMP_Text applesText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple")) // je�li zarejestrowano kolizj� z obiektem z tagiem "Apple" to zr�b....
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject); // gameObject to w tym wypadku przedmiot z tagiem "Apple"
            apples++;
            applesText.text = "Apples: " + apples;    // applesText to zmienna zawieraj�ca TextMeshPro komponent. "text" to element zawieraj�cy konfiguracj� dla komponentu TextMeshPro 
                                                      // mo�emy w ten spos�b dynamicznie zmienia� napis, pod warunkiem, �e do .text przypiszemy taki sam tekst jak w GUI Unity oraz 
                                                      // dodamy nasz� zmienn� apples.
        }
    }
}
