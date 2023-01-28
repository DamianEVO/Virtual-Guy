using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
   // private void OnCollisionEnter2D(Collision2D collision) // odpalamy skrypt (enter) przy kolizji
    //{
        //if (collision.gameObject.name == "Player") // do parametru collision dla kolizji mi�dzy paltform� a drugim elementem, przekazujemy obiekt, kt�rego nazwa to "Player". Mo�emy tak zrobi�, gdy� nie planujemy dodawa� innych obiekt�w Player. Nazwa w stringu musi by� 1:1 do nazwy obiektu.
        //{
           // collision.gameObject.transform.SetParent(transform); // obiekt Player (collision.gameObject), kt�ry przekazali�my powy�ej, ustawiamy jako dziecko w stosunku do Platformy, dzi�ki czemu transform Playera = transform Platformy i transform paltformy przekazujemy jako callback.
        //}
    //}

   // private void OnCollisionEXit2D(Collision2D collision) // po zerwaniu kolizji mi�dzy obiektami wykonujemy kod
    //{
        //if (collision.gameObject.name == "Player")
        //{
          //  collision.gameObject.transform.SetParent(null); // w momencie zerwania kolizji ustawiamy rodzica jako warto�� "null", dzi�ki czemu obiekt Player b�dzie dalej korzysta� ze swoich warto�ci transform.
       // }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
