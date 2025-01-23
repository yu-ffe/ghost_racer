using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
    private Animator Anim;
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
    private static readonly int AttackTag = Animator.StringToHash("Attack");
    void Start()
    {
        Anim = this.GetComponent<Animator>();
        Anim.CrossFade(MoveState, 0.1f, 0, 0);
    }

    void Update()
    {
        
    }
}
