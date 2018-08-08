using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();	
	}
	
	public void TriggerAnimation(CharacterAnimations animationType)
    {
        switch(animationType)
        {
            case CharacterAnimations.Hit:
                animator.SetTrigger("hit");
                break;
        }        
    }
}
