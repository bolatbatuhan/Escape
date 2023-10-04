using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float speed = 2.0f;
    public float leftBoundary = 6.0f;  // Soldaki sınır
    public float rightBoundary = 17.0f; // Sağdaki sınır

    private bool movingRight = true; // Başlangıçta sağa hareket edilsin mi?

    void Update()
    {
        // Düşmanı hareket ettir
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Düşmanın sınırlara ulaşıp ulaşmadığını kontrol et
        if (transform.position.x >= rightBoundary)
        {
            movingRight = false; // Sınırı geçince sola gitmeye başla
        }
        else if (transform.position.x <= leftBoundary)
        {
            movingRight = true; // Sınırı geçince sağa gitmeye başla
        }


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            movingRight = !movingRight;
        }
    }

}
