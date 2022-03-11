using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Git test를 위한 주석 1
// Git test를 위한 주석 2
public class Actor : MonoBehaviour
{
    [SerializeField]
    protected int MaxHP = 100;

    [SerializeField]
    protected int CurrentHP;

    [SerializeField]
    protected int Damage = 1;

    [SerializeField]
    protected int crashDamage = 100;

    [SerializeField]
    bool isDead = false;

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    public int CrashDamage
    {
        get
        {
            return crashDamage;
        }
    }
    
    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        CurrentHP = MaxHP;
    }
    
    void Update()
    {
        UpdateActor();
    }

    protected virtual void UpdateActor()
    {

    }

    public virtual void OnBulletHitted(Actor attacker, int damage)
    {
        Debug.Log("OnBulletHitted attacker : " + attacker + ", Damage : " + damage);
        DecreaseHP(attacker, damage); 
    }

    public virtual void OnCrash(Actor attacker, int damage)
    {
        Debug.Log("OnCrash damage : " + damage);
        DecreaseHP(attacker, damage);
    }

    protected virtual void DecreaseHP(Actor attacker, int damage)
    {
        if (isDead)
            return;

        CurrentHP -= damage;

        if (CurrentHP < 0)
            CurrentHP = 0;

        if (CurrentHP == 0)
            OnDead(attacker);
    }

    protected virtual void OnDead(Actor killer)
    {
        Debug.Log(name + " OnDead");
        isDead = true;

        SystemManager.Instance.EffectManager.GenerateEffect(1, transform.position);
    }
}
