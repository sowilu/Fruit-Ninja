using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splasher : MonoBehaviour
{
    private ParticleSystem particleSystem;

    public static Splasher inst;


    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void SpawnParticle(Color particleColor, Vector3 spawnPosition)
    {
        particleColor.a = 1;

        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.position = spawnPosition;
        emitParams.startColor = particleColor;

        particleSystem.Emit(emitParams, 1);
    }
}
