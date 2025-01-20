using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour, Idamagable
{
    //ü��
    [field: SerializeField] public int CurrentHp { get; set; }
    [field: SerializeField] public int MaxHp { get; set; } = 3;
    public bool HasTakenDamage { get; set ; } // true �϶� ���Ȳ���� ��������

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
            // gameObject.SetActive(false); // Enemy ������ ��Ȱ��ȭ��
            Destroy(gameObject); // Enemy ������ �����
        }
    }

}
