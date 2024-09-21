using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            BasketController basket = collision.gameObject.GetComponent<BasketController>();
            if (GetComponent<SpriteRenderer>().color == basket.GetCurrentColor())
            {
                GameManager.Instance.AddScore(1);
                MusicManager.Instance.PlayHitSound();
            }
            else
            {
                GameManager.Instance.SubtractScore(1);
                MusicManager.Instance.PlayMissSound();

            }
            Destroy(gameObject);
        }
    }
}
