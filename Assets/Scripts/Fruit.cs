using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Cursor"))
        {
            var velocity = GetComponent<Rigidbody>().velocity;
            
            //remove rigid body
            Destroy(GetComponent<Rigidbody>());
            
            //remove collider
            Destroy(GetComponent<SphereCollider>());
            
            //get children as a list
            var children = new List<Transform>();
            foreach (Transform child in transform)
            {
                children.Add(child);
            }

            var direction = Vector3.right;
            foreach(Transform child in children)
            {
                var rb = child.gameObject.AddComponent<Rigidbody>();
                rb.velocity = velocity;
                
                //push away from center
                rb.AddForce(direction * Random.Range(1, 5), ForceMode.Impulse);
                direction *= -1;

                //add rotator script
                child.gameObject.AddComponent<Rotator>();
                
                //destroy after 5 seconds
                Destroy(child.gameObject, 5f);
                
                //unparent
                child.parent = null;
            }
            
            Destroy(gameObject);
        }
    }
}
