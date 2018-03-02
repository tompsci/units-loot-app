using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCard : MonoBehaviour {

    public bool animate = false;
    public RuntimeAnimatorController cardAnimatorController;
    private Animator cardAnimator;

    // Use this for initialization
    void Start () {      

        if (animate)
        {
            cardAnimator = gameObject.AddComponent(typeof(Animator)) as Animator;
            cardAnimator.runtimeAnimatorController = cardAnimatorController as RuntimeAnimatorController;
            TriggerCardAnimation();
        }

    }

    public void TriggerCardAnimation()
    {
        cardAnimator.SetTrigger("ShowCard");
    }
}
