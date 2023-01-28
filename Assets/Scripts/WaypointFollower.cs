using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // GameObject to ogólny "super" obiekt, który okreœla nam nasz pusty obiekty (np waypoint), do którego nie jesteœmy w stanie siê inaczej odwo³aæ (nie ma koponentów itd)
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) // Vector.Distance wylicza dystans miêdzy 2 wektorami, wiêc przyjmuje 2 wartoœci  i zwraca boolean
        {                                                                                                   // powy¿szy if sprawdza - jeœli  dystans pomiêdzy pierwszym waypoint (dostaliœmy siê do niego poprzez wywo³anie zmiennej waypoints oraz podanie indeksu poprzez zmienn¹, do której mamy przypisane 0, a nastêpnie transform.position, które jest wartoœci¹ aktualnej pozycji elementu), a naszym obiektem, na który na³o¿yliœmy skrypt, czyli MovingPlatform jest mniejszy niz 0.1, to...
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) // waypoints.Length okreœla liczbê elementów w tablicy. Fajne i uniwersalne, bo waypointów mo¿e byæ wiêcej.
            {
                currentWaypointIndex = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        // do pozycji platformy przypisujemy metodê Vector2.MoveTowards(), która przesuwa element a w stronê elementu b, co ka¿d¹ klatkê(frame).
        // jako a przyjmujemy nasz¹ platformê, a jako b aktualny waypoint w zale¿noœci od powy¿szego if-a, wiêc platforma przesuwa siê w stronê pozycji waypoint 1/2
        // trzeci argument okreœla prêdkoœæ poruszania siê elementu. Time.deltaTime natomiast to interwa³ w sekundach pomiêdzy ostatni¹ klatk¹ a bie¿¹c¹ klatk¹, tak wiêc Time.deltaTime * speed oznacza poruszanie siê 2 "games units" per second. U¿ywamy tego poniewa¿ ustawienie iloœci units na sekunde na sztywno mo¿e siê ró¿nic w zale¿noœci od iloœci klatek na danym urz¹dzeniu.
    }
}
