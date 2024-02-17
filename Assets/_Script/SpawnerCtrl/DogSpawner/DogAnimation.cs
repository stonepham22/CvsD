using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimation : BaseDogPrefab
{
    [SerializeField] private const string IS_DEAD = "isDead";
    [SerializeField] private const string IS_ATTACK = "isAttack";
    
    public void SetDead()
    {
        this.dogPrefabCtrl.Animator.SetBool(IS_DEAD, true);
    }

    public void SetAttack(bool value)
    {
        this.dogPrefabCtrl.Animator.SetBool(IS_ATTACK, value);
    }

}
