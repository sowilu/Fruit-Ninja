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
    private AudioSource audioSource;
    
    
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));   
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(SpawnTest());
    }

    IEnumerator SpawnTest()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            StartCoroutine(StartWave());
        }
    }
    
    IEnumerator StartWave()
    {
        var count = Random.Range(1, maxFruits);
        
        for (int i = 0; i < count; i++)
        {
            TossRandomFruit();

            var waitTime = Random.Range(0, 1 / spawnRate);
            yield return new WaitForSeconds(waitTime);
        }

        //yield return new WaitForSeconds(timeBetweenWaves);
    }

    void TossRandomFruit()
    {
        //set random pitch
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(audioSource.clip);

        var fruitPrefab = fruits[Random.Range(0, fruits.Count)];
        var position = new Vector3(Random.Range(-screenBounds.x / 3 * 2, screenBounds.x / 3 * 2), transform.position.y, 0);
        var fruit = Instantiate(fruitPrefab, position, Quaternion.identity);
        
        var tossDirection = Vector3.up * 15 + Vector3.right * Random.Range(-2, 2);
            
        //toss fruit up with physics
        fruit.GetComponent<Rigidbody>().AddForce(tossDirection, ForceMode.Impulse);
    }



}
