using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertAnimationController {

    private Animator animator;

    public AlertAnimationController(Animator anim)
    {
        animator = anim;
    }
	
	public void TriggerAnimation(AlertAnimations alertAnimation)
    {
        switch (alertAnimation)
        {
            case AlertAnimations.FadeIn:
                animator.SetTrigger("fadeIn");
                break;
            case AlertAnimations.FadeOut:
                animator.SetTrigger("fadeOut");
                break;
        }
    }
}
