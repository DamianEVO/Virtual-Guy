using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) // if, kt�ry sprawdza kolizj� z obiektem o tagu "Trap"
        {
            Die(); // je�li taka kolizja mi�dzy "Trap", a graczem b�dzie mia�a miejsce - wywo�ujemy te metod�
        }
    }

    private void Die() // nowa metoda Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death"); // ten kod odpali Trigger, kt�ry ustawili�my w unity w Animatorze "death". Dzi�ki temu przy kolizji animator odpali animacj� znikania.
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
