using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour {
    private bool isSequencing = false;

    public bool IsSequencing()
    {
        return isSequencing;
    }

    public void StartSequence(ProjectileSequence projectileSequence, ProjectileManager projectileManager)
    {
        isSequencing = true;
        StartCoroutine(LoopSequence(projectileSequence, projectileManager));
    }

    IEnumerator LoopSequence(ProjectileSequence projectileSequence, ProjectileManager projectileManager)
    {
        yield return new WaitForSeconds(projectileSequence.beginOffset);

        foreach (SequenceElement element in projectileSequence.sequence)
        {
            projectileManager.SpawnProjectile(element.projectileSpawner);
            yield return new WaitForSeconds(element.timeAfter);
        }

        isSequencing = false;
    }
}
