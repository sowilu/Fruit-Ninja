using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //on collision with fruit play
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Fruit"))
        {
            //change pitch
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
        }
    }
}
