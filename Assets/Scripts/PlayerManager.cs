using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rigi;

    Image HealthBar;
    public GameObject player;
    public float health = 100;
    public float currentHealth;

    float getDamage = 20;


    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        currentHealth = health;
        HealthBar = GameObject.Find("Canvas/healthBar/health").GetComponent<Image>();
        HealthBar.fillAmount = currentHealth / health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            currentHealth -= getDamage;

            rigi.AddForce(new Vector2(3f, 5f), ForceMode2D.Impulse);

            if (currentHealth == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


    void Update()
    {
        HealthBar.fillAmount = currentHealth / health;
        if (player.transform.position.y < -8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
