using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class water : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyun sahnesini yeniden yükle
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
