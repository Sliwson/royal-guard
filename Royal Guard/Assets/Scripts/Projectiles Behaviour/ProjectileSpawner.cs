using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProjectileSpawner : MonoBehaviour
{
    public Transform location = null;
    public Vector2 velocity = Vector2.zero;
    public GameObject projectilePrefab;
}