using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float attackCD = 0.15f;

    RaycastHit2D[] hits;
    Animator anim;
    private float attackCoolTimeCheck;

    public bool ShouldBeDamage { get; set; }

    private List<Idamagable> idamagables = new(); // == new List<Idamagable>();

    private void Start()
    {
        anim = GetComponent<Animator>();
        attackCoolTimeCheck = attackCD;
    }

    private void Update()
    {
        if (InputUser.Instance.control.Attack.MeleeAttack.WasPressedThisFrame() && attackCoolTimeCheck >= attackCD) 
        {
            attackCoolTimeCheck = 0;
            
            anim.SetTrigger("attack");
        }
        attackCoolTimeCheck += Time.deltaTime;
    }

    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0, attackableLayer);
              
        for (int i = 0; i < hits.Length; i++)
        {
            Idamagable enemyHP = hits[i].collider.GetComponent<Idamagable>();

            if (enemyHP != null)
            {
                enemyHP.Damage(damageAmount);
            }
        }
    }

    public IEnumerator AttackAvailable()
    {
        ShouldBeDamage = true;

        while (ShouldBeDamage)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0, attackableLayer);

            for (int i = 0; i < hits.Length; i++)
            {
                Idamagable enemyHP = hits[i].collider.GetComponent<Idamagable>();
                                
                if (enemyHP != null&& !enemyHP.HasTakenDamage)
                {
                    enemyHP.Damage(damageAmount);
                    idamagables.Add(enemyHP);
                }
            }
            yield return null; 
        }

        // ������ �ٽ� �� �� �ִ� �����Դϴ�.
        ReturnAttackableState();
    }

    private void ReturnAttackableState()
    {
       // idamagable �迭, List
       // idamagables ����Ʈ �ȿ� �ִ� ��� ���Ұ� HasTakenDamage�� false�� �ٲ��.

        foreach(var damaagable in idamagables)
        {
            damaagable.HasTakenDamage = false;
        }
    }

    public void ShouldBeDamageTrue()
    {
        ShouldBeDamage = true;
    }


    public void ShouldBeDamageFalse()
    {
        ShouldBeDamage = false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

}
