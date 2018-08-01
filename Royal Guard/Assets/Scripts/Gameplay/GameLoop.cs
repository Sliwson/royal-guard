using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    [SerializeField]
    private ProjectileManager projectileManager;

    [SerializeField]
    private SequenceManager sequenceManager;

    public bool loop = false;

    private void Update()
    {
        if(loop && sequenceManager.IsSequencing() == false)
            projectileManager.StartSequence();
    }
}
