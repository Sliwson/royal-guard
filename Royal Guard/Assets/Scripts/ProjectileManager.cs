using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {
    [System.Serializable]
    private class ProjectileSpawner
    {
        public Transform location = null;
        public Vector2 velocity = Vector2.zero;
        public GameObject projectilePrefab;
    }
        
    [SerializeField]
    private ProjectileSpawner[] projectileSpawners;
    
    [ContextMenu("Spawn random projectile")]
    public void SpawnRandomProjectile()
    {
        int index = Random.Range(0, projectileSpawners.Length);

        SpawnProjectile(projectileSpawners[index]);
    }

    [ContextMenu("Spawn 10 random projectiles")]
    public void SpawnRandomProjectiles()
    {
        float timeOffset = 1f;
        int count = 10;

        for (int i = 0; i < count; i++)
            Invoke("SpawnRandomProjectile", timeOffset * i);
    }
    private void SpawnProjectile(ProjectileSpawner spawner)
    {
        GameObject prefab = Instantiate(spawner.projectilePrefab, spawner.location) as GameObject;

        Projectile projectileScript = prefab.GetComponent<Projectile>();

        projectileScript.Push(spawner.velocity);
    }
}
