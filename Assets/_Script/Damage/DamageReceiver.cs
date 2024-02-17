using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class DamageReceiver : LoboMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 2;
    [SerializeField] protected bool isDead = false;
    public int HP => hp;
    public int HPMax => hpMax;

    protected virtual void OnEnable()
    {
        this.Reborn();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    
    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }
    public virtual void Add(int add)
    {
        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }
    public virtual void Deduct(int deduct)
    {
        if (this.isDead) return;

        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }
    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected virtual void OnDead()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
