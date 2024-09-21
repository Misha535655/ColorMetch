using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] shapes;        
    public float speed = 5f;          
    public float minX, maxX;          
    public int minShapesPerSpawn = 3; 
    public int maxShapesPerSpawn = 6;  

    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f; 

    private Color[] possibleColors = {
        Color.red,
        Color.blue,
        Color.green,
        new Color(1f, 0.65f, 0f),
        new Color(0.5f, 0f, 0.5f)
    };
    private void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        StartCoroutine(SpawnShapesWithRandomInterval());
    }

    private IEnumerator SpawnShapesWithRandomInterval()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            SpawnShapeRain();
        }
    }

    private void SpawnShapeRain()
    {
        int shapesToSpawn = Random.Range(minShapesPerSpawn, maxShapesPerSpawn + 1);

        for (int i = 0; i < shapesToSpawn; i++)
        {
            int randomShapeIndex = Random.Range(0, shapes.Length);

            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

            GameObject shape = Instantiate(shapes[randomShapeIndex], spawnPosition, Quaternion.identity);

            shape.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

            int randomIndex = Random.Range(0, possibleColors.Length);
            shape.GetComponent<SpriteRenderer>().color = possibleColors[randomIndex];
          
            Destroy(shape, 10f);
        }
    }
}
