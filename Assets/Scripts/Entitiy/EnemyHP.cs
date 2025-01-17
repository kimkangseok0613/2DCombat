using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour, Idamagable
{
    //Ã¼·Â
    [field: SerializeField] public int CurrentHp { get; set; }
    [field: SerializeField] public int MaxHp { get; set; } = 3;

    private void Start()
    {
        CurrentHp = MaxHp;
    }

    public void Damage(int amount)
    {
        CurrentHp -= amount;
        Die();
    }

    public void Die()
    {
        if (CurrentHp <= 0)
        {
            // gameObject.SetActive(false); // Enemy Á×À¸¸é ºñÈ°¼ºÈ­µÊ
            Destroy(gameObject); // Enemy Á×À¸¸é »ç¶óÁü
        }
    }

}
