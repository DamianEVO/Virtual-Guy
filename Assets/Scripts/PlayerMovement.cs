using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; // tak tworzymy zmienn� (rg = skr�t dla RigidBody). Private sprawia, �e ta zmienna jest dost�pna wy��cznie dla tego skryptu. Dobra praktyka jest, aby nie zostawia� nieokre�lonych zmiennych.
                            // int wholeNumber = 16; // tak tworzymy zmienn� dla ca�ej liczby
                            // float devimalNumber = 4.54f; // tak tworzymy zmienn� dla dziesi�tnej liczby. Warto pami�ta� o "f" na ko�cu - czasem jest niezb�dne, czasem nie, ale jak nie wiemy to lepiej doda�
                            // string text = "blabla"; // tak tworzymy zmienn� string
                            // bool bollean = false; // tak tworzymy zmienn� z booleanem
    private Animator anim; // w ten spos�b dostajemy si� do okna Animator w Unity, a zmienn� nazywamy anim
    private SpriteRenderer sprite; // zmienna sprite z dost�pem do SpriteRenderer
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX; // tak tworzymy zmienn� numeryczn� globaln� (globaln� w zakresie skryptu ofc) Mo�na tak�e przypisa� warto�� = 0f na start, jakby kod mia� k�opot i si� czepia�, �e nie ma warto�ci.
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f; // [SerializeField] pozwala na przeniesienie danej zmiennej do Unity. B�dzie widoczna w oknie Scripts.
                                                    // mogliby�my te zmienne tak�e ustawi� na "public" i zadzia�� to podobnie i b�dzie widoczne w Unity, natomiast nie jest to zalecane, gdy� pozosta�e skrypty tak�e b�d� mia�y dost�p do tych zmiennych.

    private enum MovementState { idle, running, jumping, falling } // enum pozwala nam okre�li� rodzaj "enum", do kt�rego w nawiasach klamrowych przypisujemy jakie� warto�ci
                                                                   // private MovementState state = MovementState.idle; // nast�pnie wywo�uj�c powy�szy enum, mo�emy stworzy� zmienn� "state", do kt�rej mo�emy przypisa� wy��cznie warto�� zawieraj�c� si� w nawiasach klamrowych

    [SerializeField] private AudioSource jumpSoundEffect; // w ten spos�b mo�emy doda� pole z d�wi�kiem do Unity dla obiektu Player. Nie korzystamy w tym wypadku z GetComponent, poniewa� mamy kilka r�nych d�wi�k�w dla tego obiektu i musimy je jako� ror�ni�. Inaczej ma si� sytuacja dla skryptu Finish.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // do zmiennej rb przypisujemy Rigidbody2D
        anim = GetComponent<Animator>(); // do zmiennej anim przypisujemy Animatora
        sprite = GetComponent<SpriteRenderer>(); // do zmiennej sprite przypisujemy SpriteRenderer
        coll = GetComponent<BoxCollider2D>(); // do zmiennej call przypisujemy BoxCollider2D
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // do zmiennej numerycznej dirX przypisali�my o� poziom� (nazwa z input managera) umo�liwaj�c� ruch klawiszami wskazanymi w input managerze [warto�� pojedynczego ruchu na osi X b�dzie si� waha�a mi�dzy -1 w lewo a 1 w prawo]
                                                    // GetAxis samo sprawia, �e po puszczeniu klawisza warto�� osi X nie spada natychmiast do 0. Jest to dobre, ale dla gier bardziej realistycznych. Dla 2D powinni�my u�y� GetAxisRaw, kt�re natychmiast stopuje ruch po puszczeniu klawisza.
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); // przypisujemy do pr�dko�ci rigid body nowy Wektor (2, gdy� dla 2D wystarcz� nam dwie osie). Warto�� ruchu (7) jest mno�ona przez ruch dirX, aby zar�wno w lewo (-1 x7), jak i w prawo (1x7) ruch wygl�da� tak samo
                                                             // a o� Y zostawiamy domy�ln�, �eby nie ustawia� warto�ci 0, gdy� mo�emy przerywa� sobie skok w takim wypadku.

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
           jumpSoundEffect.Play();
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState() // stworzyli�my now� funkcj�, �eby nie zasyfi� funkcji Update() - tutaj mo�emy dodawa� wszelkie elementy zwi�zane z animacjami, a nast�pnie sam� funkcj� wywo�ywa� w Update()
                                        // void m�wi nam o tym, �e funkcja nic nam nie zwraca, wy��cznie wykonuje dany kod i tyle.
    {
        MovementState state;

        if (dirX > 0f) // sprawdzamy czy warto�� na osi X jest wi�ksza od 0. Je�li tak to wykonujemy poni�zy kod (w tym wypadku nie u�ywamy zapisu dirX != 0f, gdy� poni�sze ify b�d� spe�nia�y jeszcze inne funkcje.
        {
            state = MovementState.running;
            sprite.flipX = false; // tak dostajemy si� do opcji "Flip" na osi X w SpriteRendererze i mo�emy ustawi� warto�� na true/false (checkbox)
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); // zwraca true/false
    }
}
