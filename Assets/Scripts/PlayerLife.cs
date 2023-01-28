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
        if (collision.gameObject.CompareTag("Trap")) // if, który sprawdza kolizjê z obiektem o tagu "Trap"
        {
            Die(); // jeœli taka kolizja miêdzy "Trap", a graczem bêdzie mia³a miejsce - wywo³ujemy te metodê
        }
    }

    private void Die() // nowa metoda Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death"); // ten kod odpali Trigger, który ustawiliœmy w unity w Animatorze "death". Dziêki temu przy kolizji animator odpali animacjê znikania.
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
