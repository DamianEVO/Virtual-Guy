using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
   public void Quit()
    {
        Application.Quit(); // metoda, kt�ra wy��cza nam aplikacje (nie dzia�a w preview mode, ale powinna dzia�a� w normalnej grze
    }
}
