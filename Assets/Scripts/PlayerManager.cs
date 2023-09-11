using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rigi;
    public float health = 100;
    public float currentHealth;
    float getDamage = 10;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        currentHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            currentHealth = health - getDamage;
            rigi.AddForce(new Vector2(3f, 5f),ForceMode2D.Impulse);

            if(currentHealth == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = currentHealth;
    }
}
