using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; // tak tworzymy zmienn¹ (rg = skrót dla RigidBody). Private sprawia, ¿e ta zmienna jest dostêpna wy³¹cznie dla tego skryptu. Dobra praktyka jest, aby nie zostawiaæ nieokreœlonych zmiennych.
                            // int wholeNumber = 16; // tak tworzymy zmienn¹ dla ca³ej liczby
                            // float devimalNumber = 4.54f; // tak tworzymy zmienn¹ dla dziesiêtnej liczby. Warto pamiêtaæ o "f" na koñcu - czasem jest niezbêdne, czasem nie, ale jak nie wiemy to lepiej dodaæ
                            // string text = "blabla"; // tak tworzymy zmienn¹ string
                            // bool bollean = false; // tak tworzymy zmienn¹ z booleanem
    private Animator anim; // w ten sposób dostajemy siê do okna Animator w Unity, a zmienn¹ nazywamy anim
    private SpriteRenderer sprite; // zmienna sprite z dostêpem do SpriteRenderer
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX; // tak tworzymy zmienn¹ numeryczn¹ globaln¹ (globaln¹ w zakresie skryptu ofc) Mo¿na tak¿e przypisaæ wartoœæ = 0f na start, jakby kod mia³ k³opot i siê czepia³, ¿e nie ma wartoœci.
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f; // [SerializeField] pozwala na przeniesienie danej zmiennej do Unity. Bêdzie widoczna w oknie Scripts.
                                                    // moglibyœmy te zmienne tak¿e ustawiæ na "public" i zadzia³¹ to podobnie i bêdzie widoczne w Unity, natomiast nie jest to zalecane, gdy¿ pozosta³e skrypty tak¿e bêd¹ mia³y dostêp do tych zmiennych.

    private enum MovementState { idle, running, jumping, falling } // enum pozwala nam okreœliæ rodzaj "enum", do którego w nawiasach klamrowych przypisujemy jakieœ wartoœci
                                                                   // private MovementState state = MovementState.idle; // nastêpnie wywo³uj¹c powy¿szy enum, mo¿emy stworzyæ zmienn¹ "state", do której mo¿emy przypisaæ wy³¹cznie wartoœæ zawieraj¹c¹ siê w nawiasach klamrowych

    [SerializeField] private AudioSource jumpSoundEffect; // w ten sposób mo¿emy dodaæ pole z dŸwiêkiem do Unity dla obiektu Player. Nie korzystamy w tym wypadku z GetComponent, poniewa¿ mamy kilka ró¿nych dŸwiêków dla tego obiektu i musimy je jakoœ roró¿niæ. Inaczej ma siê sytuacja dla skryptu Finish.

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
        dirX = Input.GetAxisRaw("Horizontal"); // do zmiennej numerycznej dirX przypisaliœmy oœ poziom¹ (nazwa z input managera) umo¿liwaj¹c¹ ruch klawiszami wskazanymi w input managerze [wartoœæ pojedynczego ruchu na osi X bêdzie siê waha³a miêdzy -1 w lewo a 1 w prawo]
                                                    // GetAxis samo sprawia, ¿e po puszczeniu klawisza wartoœæ osi X nie spada natychmiast do 0. Jest to dobre, ale dla gier bardziej realistycznych. Dla 2D powinniœmy u¿yæ GetAxisRaw, które natychmiast stopuje ruch po puszczeniu klawisza.
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); // przypisujemy do prêdkoœci rigid body nowy Wektor (2, gdy¿ dla 2D wystarcz¹ nam dwie osie). Wartoœæ ruchu (7) jest mno¿ona przez ruch dirX, aby zarówno w lewo (-1 x7), jak i w prawo (1x7) ruch wygl¹da³ tak samo
                                                             // a oœ Y zostawiamy domyœln¹, ¿eby nie ustawiaæ wartoœci 0, gdy¿ mo¿emy przerywaæ sobie skok w takim wypadku.

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
           jumpSoundEffect.Play();
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState() // stworzyliœmy now¹ funkcjê, ¿eby nie zasyfiæ funkcji Update() - tutaj mo¿emy dodawaæ wszelkie elementy zwi¹zane z animacjami, a nastêpnie sam¹ funkcjê wywo³ywaæ w Update()
                                        // void mówi nam o tym, ¿e funkcja nic nam nie zwraca, wy³¹cznie wykonuje dany kod i tyle.
    {
        MovementState state;

        if (dirX > 0f) // sprawdzamy czy wartoœæ na osi X jest wiêksza od 0. Jeœli tak to wykonujemy poniœzy kod (w tym wypadku nie u¿ywamy zapisu dirX != 0f, gdy¿ poni¿sze ify bêd¹ spe³nia³y jeszcze inne funkcje.
        {
            state = MovementState.running;
            sprite.flipX = false; // tak dostajemy siê do opcji "Flip" na osi X w SpriteRendererze i mo¿emy ustawiæ wartoœæ na true/false (checkbox)
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
