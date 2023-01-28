using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // w tym miejscu speed wykorzystamy jako iloœæ razy, któr¹ element obróci siê o 360 stopni w ci¹gu sekundy, czyli w tym wypadku bêdzie 720 stopni.

    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime); // metoda Rotate odpowiada wartoœci¹ "rotate" dla danego elementu. Chcemy wy³¹cznie obracaæ w osi Z, st¹d te wartoœci. W "z" chcemy na 1 sekundê obracaæ dwukrotnie, wiêc mno¿ymy przez zmienn¹ speed oraz mno¿ymy przez deltaTime, która zapewnia niezale¿noœæ frame-ow¹.
                                                              // Time.deltaTime odpowiada za 1 sekundê dla iloœci frame na danym sprzêcie, czyli w zale¿noœci jakie mamy frame ratio lokalnie, nasza funkcja dostosuje prêdkoœæ do iloœci tych klatek. Gdybyœmy ustawili szybkoœæ manualnie, to w zale¿noœci od urz¹dzenia, animacja wygl¹da³aby inaczej.
    }
}
