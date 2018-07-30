using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {
    [SerializeField]
    private Transform projectilePartent;

    [SerializeField]
    private ProjectileSequence projectileSequence;

    private SequenceManager sequenceManager;

    private void Start()
    {
        sequenceManager = GetComponent<SequenceManager>();
    }

    [ContextMenu("Start sequence")]
    public void StartSequence()
    {
        sequenceManager.StartSequence(projectileSequence ,this);
    }

    public void SpawnProjectile(ProjectileSpawner spawner)
    {
        GameObject prefab = Instantiate(spawner.projectilePrefab, spawner.location.position, Quaternion.identity, projectilePartent) as GameObject;

        Projectile projectileScript = prefab.GetComponent<Projectile>();

        projectileScript.Push(spawner.velocity);
    }
}
