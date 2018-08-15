using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldParticles : MonoBehaviour {

    [SerializeField]
    private Transform leftParticleTransform;
    [SerializeField]
    private Transform rightParticleTransform;
    [SerializeField]
    private Range resetRange;
    [SerializeField]
    private float angleOffset = 1f;
    [SerializeField]
    private GameObject particlePrefab;

    private Controlls controlls;
    private Range range;
    private bool canSpawn = false;

    private void Start()
    {
        controlls = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controlls>();
        range = controlls.GetRange();
    }

    private void Update()
    {
        float currentAngle = controlls.GetCurrentAngle();

        if (currentAngle > resetRange.min && currentAngle < resetRange.max)
        {
            canSpawn = true;
        }
        else if (canSpawn)
        { 
            if (currentAngle < range.min + angleOffset)
            {
                SpawnParticle(Direction.Left);
                canSpawn = false;
            }
            else if (currentAngle > range.max - angleOffset)
            {
                SpawnParticle(Direction.Right);
                canSpawn = false;
            }
        }
    }

    private void SpawnParticle(Direction direction)
    {
        Transform spawnTransform = GetSpawnTransform(direction);

        GameObject prefab = Instantiate(particlePrefab, spawnTransform.position, Quaternion.identity, spawnTransform) as GameObject;

        ParticleSystem particleSystem = prefab.GetComponent<ParticleSystem>();

        particleSystem.Play();
    }

    private Transform GetSpawnTransform(Direction direction)
    {
        switch (direction)
        {
            case Direction.Right:
                return rightParticleTransform;
            case Direction.Left:
                return leftParticleTransform;
            default:
                return rightParticleTransform;
        }
    }
}
