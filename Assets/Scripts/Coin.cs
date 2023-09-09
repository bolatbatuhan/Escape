using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.instance.addScore(coinValue);
        Destroy(gameObject);
    }

}
