using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Idamagable
{
    public int CurrentHp { get; set; }
    public int MaxHp { get; set; }

    public void Damage(int amount);

    public void Die();
}
