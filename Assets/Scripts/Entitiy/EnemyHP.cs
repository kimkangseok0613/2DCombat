using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour, Idamagable
{
    //체력
    [field: SerializeField] public int CurrentHp { get; set; }
    [field: SerializeField] public int MaxHp { get; set; } = 3;
    public bool HasTakenDamage { get; set ; } // true 일때 어떤상황으로 정의할지

    private void Start()
    {
        CurrentHp = MaxHp;
    }

    public void Damage(int amount)
    {
        HasTakenDamage = true;
        CurrentHp -= amount;
        Die();
    }

    public void Die()
    {
        if (CurrentHp <= 0)
        {
            // gameObject.SetActive(false); // Enemy 죽으면 비활성화됨
            Destroy(gameObject); // Enemy 죽으면 사라짐
        }
    }

}
