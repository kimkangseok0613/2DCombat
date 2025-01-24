using Cinemachine;
using UnityEngine;

public class GrassHP : BaseHP
{
    
    public override void Damage(int amount, Vector2 attackDirection)
    {
        HasTakenDamage = true;
        CurrentHp -= amount;
        
        // Sound

        PlayRandomDamageSound();

        // Effect
        SpawnDamageParticle(attackDirection);

        Die();
    }
}
