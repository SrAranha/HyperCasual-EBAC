using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : Singleton<PlayerAnimation>
{
    public Animator animator;
    [Header("Animation Triggers")]
    public List<AnimationList> animations;

    public enum AnimationTypes
    {
        IDLE,
        RUN,
        DEATH
    }
    public void PlayAnimation(AnimationTypes type = AnimationTypes.IDLE)
    {
        foreach (var animation in animations)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }
}
[Serializable]
public class AnimationList
{
    public PlayerAnimation.AnimationTypes type;
    public string trigger;
}