using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Alert : MonoBehaviour {

    [SerializeField]
    private float screenBorderOffset = 2f;

    private bool fadedOut = false;

    private Coordinates screenCorners;
    private AlertAnimationController alertAnimationController;

    public void SpawnAlert(Transform transform)
    {
        alertAnimationController = new AlertAnimationController(GetComponent<Animator>());
        alertAnimationController.TriggerAnimation(AlertAnimations.FadeIn);
    }

    public void UpdateAlert(Transform position)
    {
        
    }

    public void DestroyAlert()
    {
        Destroy(gameObject);
    }
}
