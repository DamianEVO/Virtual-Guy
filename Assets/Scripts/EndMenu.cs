using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
   public void Quit()
    {
        Application.Quit(); // metoda, która wy³¹cza nam aplikacje (nie dzia³a w preview mode, ale powinna dzia³aæ w normalnej grze
    }
}
