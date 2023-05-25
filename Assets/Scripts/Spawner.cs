using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> fruits;
    
    public int maxFruits = 5;
    public float spawnRate = 2f;
    public float timeBetweenWaves = 5f;

    private Vector2 screenBounds;
    
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));   
        
        StartCoroutine(SpawnTest());
    }

    IEnumerator SpawnTest()
    {
        while (true)
        {
            StartCoroutine(StartWave());
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
    
    IEnumerator StartWave()
    {
        var count = Random.Range(1, maxFruits);
        
        for (int i = 0; i < count; i++)
        {
            var fruitPrefab = fruits[Random.Range(0, fruits.Count)];
            var position = new Vector3(Random.Range(-screenBounds.x / 3, screenBounds.x / 3), transform.position.y, 0);
            var fruit = Instantiate(fruitPrefab, position, Quaternion.identity);
            
            //toss fruit up with physics
            fruit.GetComponent<Rigidbody>().AddForce(Vector3.up * 15, ForceMode.Impulse);

            var waitTime = Random.Range(0, 1 / spawnRate);
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitForSeconds(timeBetweenWaves);
    }



}
