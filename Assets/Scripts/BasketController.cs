using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 touchPosition;
    private Vector3 targetPosition;
    private float minX, maxX;

    private SpriteRenderer spriteRenderer;

    private Color[] possibleColors = {
        Color.red,
        Color.blue,
        Color.green,
        new Color(1f, 0.65f, 0f),  
        new Color(0.5f, 0f, 0.5f)  
    };

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        StartCoroutine(ChangeColorAtRandomIntervals());
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
            targetPosition = new Vector3(Mathf.Clamp(touchPosition.x, minX, maxX), transform.position.y, 0);
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    private IEnumerator ChangeColorAtRandomIntervals()
    {
        while (true)
        {
            float randomInterval = Random.Range(3f, 6f);

            ChangeColor();

            yield return new WaitForSeconds(randomInterval);
        }
    }

    private void ChangeColor()
    {
        int randomIndex = Random.Range(0, possibleColors.Length);
        spriteRenderer.color = possibleColors[randomIndex];
    }

    public Color GetCurrentColor()
    {
        return spriteRenderer.color;
    }
}
