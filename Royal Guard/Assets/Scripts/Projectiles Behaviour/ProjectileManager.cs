using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {
    [SerializeField]
    private Transform projectilePartent;

    [SerializeField]
    private ProjectileSequence projectileSequence;

    [SerializeField]
    private Vector2 projectileHitKnockback = Vector2.zero;

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

    public void KnockbackProjectile(Projectile projectile)
    {
        projectile.Push(projectileHitKnockback);
    }

    public void SpawnProjectile(ProjectileSpawner spawner)
    {
        GameObject prefab = Instantiate(spawner.projectilePrefab, spawner.location.position, Quaternion.identity, projectilePartent) as GameObject;

        Projectile projectileScript = prefab.GetComponent<Projectile>();

        projectileScript.Push(spawner.velocity);
    }
}
