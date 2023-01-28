using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
   // private void OnCollisionEnter2D(Collision2D collision) // odpalamy skrypt (enter) przy kolizji
    //{
        //if (collision.gameObject.name == "Player") // do parametru collision dla kolizji miêdzy paltform¹ a drugim elementem, przekazujemy obiekt, którego nazwa to "Player". Mo¿emy tak zrobiæ, gdy¿ nie planujemy dodawaæ innych obiektów Player. Nazwa w stringu musi byæ 1:1 do nazwy obiektu.
        //{
           // collision.gameObject.transform.SetParent(transform); // obiekt Player (collision.gameObject), który przekazaliœmy powy¿ej, ustawiamy jako dziecko w stosunku do Platformy, dziêki czemu transform Playera = transform Platformy i transform paltformy przekazujemy jako callback.
        //}
    //}

   // private void OnCollisionEXit2D(Collision2D collision) // po zerwaniu kolizji miêdzy obiektami wykonujemy kod
    //{
        //if (collision.gameObject.name == "Player")
        //{
          //  collision.gameObject.transform.SetParent(null); // w momencie zerwania kolizji ustawiamy rodzica jako wartoœæ "null", dziêki czemu obiekt Player bêdzie dalej korzysta³ ze swoich wartoœci transform.
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
