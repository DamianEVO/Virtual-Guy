using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // w tym miejscu speed wykorzystamy jako ilo�� razy, kt�r� element obr�ci si� o 360 stopni w ci�gu sekundy, czyli w tym wypadku b�dzie 720 stopni.

    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime); // metoda Rotate odpowiada warto�ci� "rotate" dla danego elementu. Chcemy wy��cznie obraca� w osi Z, st�d te warto�ci. W "z" chcemy na 1 sekund� obraca� dwukrotnie, wi�c mno�ymy przez zmienn� speed oraz mno�ymy przez deltaTime, kt�ra zapewnia niezale�no�� frame-ow�.
                                                              // Time.deltaTime odpowiada za 1 sekund� dla ilo�ci frame na danym sprz�cie, czyli w zale�no�ci jakie mamy frame ratio lokalnie, nasza funkcja dostosuje pr�dko�� do ilo�ci tych klatek. Gdyby�my ustawili szybko�� manualnie, to w zale�no�ci od urz�dzenia, animacja wygl�da�aby inaczej.
    }
}
