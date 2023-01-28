using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // GameObject to og�lny "super" obiekt, kt�ry okre�la nam nasz pusty obiekty (np waypoint), do kt�rego nie jeste�my w stanie si� inaczej odwo�a� (nie ma koponent�w itd)
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) // Vector.Distance wylicza dystans mi�dzy 2 wektorami, wi�c przyjmuje 2 warto�ci  i zwraca boolean
        {                                                                                                   // powy�szy if sprawdza - je�li  dystans pomi�dzy pierwszym waypoint (dostali�my si� do niego poprzez wywo�anie zmiennej waypoints oraz podanie indeksu poprzez zmienn�, do kt�rej mamy przypisane 0, a nast�pnie transform.position, kt�re jest warto�ci� aktualnej pozycji elementu), a naszym obiektem, na kt�ry na�o�yli�my skrypt, czyli MovingPlatform jest mniejszy niz 0.1, to...
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) // waypoints.Length okre�la liczb� element�w w tablicy. Fajne i uniwersalne, bo waypoint�w mo�e by� wi�cej.
            {
                currentWaypointIndex = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        // do pozycji platformy przypisujemy metod� Vector2.MoveTowards(), kt�ra przesuwa element a w stron� elementu b, co ka�d� klatk�(frame).
        // jako a przyjmujemy nasz� platform�, a jako b aktualny waypoint w zale�no�ci od powy�szego if-a, wi�c platforma przesuwa si� w stron� pozycji waypoint 1/2
        // trzeci argument okre�la pr�dko�� poruszania si� elementu. Time.deltaTime natomiast to interwa� w sekundach pomi�dzy ostatni� klatk� a bie��c� klatk�, tak wi�c Time.deltaTime * speed oznacza poruszanie si� 2 "games units" per second. U�ywamy tego poniewa� ustawienie ilo�ci units na sekunde na sztywno mo�e si� r�nic w zale�no�ci od ilo�ci klatek na danym urz�dzeniu.
    }
}
