using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100;
    private Vector3 direction;
    
    void Start()
    {
        direction.x = Random.Range(-1, 1);
        direction.y = Random.Range(-1, 1);
        direction.z = Random.Range(-1, 1);
    }
    
    void Update()
    {
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}
