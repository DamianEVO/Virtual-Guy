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
        if (collision.gameObject.CompareTag("Apple")) // jeœli zarejestrowano kolizjê z obiektem z tagiem "Apple" to zrób....
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject); // gameObject to w tym wypadku przedmiot z tagiem "Apple"
            apples++;
            applesText.text = "Apples: " + apples;    // applesText to zmienna zawieraj¹ca TextMeshPro komponent. "text" to element zawieraj¹cy konfiguracjê dla komponentu TextMeshPro 
                                                      // mo¿emy w ten sposób dynamicznie zmieniaæ napis, pod warunkiem, ¿e do .text przypiszemy taki sam tekst jak w GUI Unity oraz 
                                                      // dodamy nasz¹ zmienn¹ apples.
        }
    }
}
