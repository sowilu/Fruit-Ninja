using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
    public GameObject juiceVfx;
    public Color juiceColor;
    
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
            
            Score.instance.Points++;

            //spawn juice
            var juice = Instantiate(juiceVfx, transform.position, Quaternion.identity);
            var main = juice.GetComponent<ParticleSystem>().main;
            main.startColor = juiceColor;


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
