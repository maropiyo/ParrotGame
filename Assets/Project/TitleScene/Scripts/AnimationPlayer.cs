using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    // アニメーターコンポーネント配列
    public Animator[] animators;

    void Start()
    {
        // アニメーターを再生する
        foreach (Animator animator in animators)
        {
            animator.Play("TitleAnimation");
        }
    }
}
