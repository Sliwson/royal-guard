using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimationController : MonoBehaviour {

    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();	
	}
	
	public void TriggerAnimation(ShieldAnimations shieldAnimation)
    {
        switch(shieldAnimation)
        {
            case ShieldAnimations.Hit:
                animator.SetTrigger("hit");
                break;

        }
    }
}
