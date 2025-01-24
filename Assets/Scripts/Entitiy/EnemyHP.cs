using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]

public class EnemyHP : BaseHP
{   
    private CinemachineImpulseSource _impulseSource;
    [SerializeField] private ScreenShakeSO profile;

    HPBar _hpBar;

    protected override void Start()
    {
        base.Start();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _hpBar=GetComponentInChildren<HPBar>();
    }

    public override void Damage(int amount, Vector2 attackDirection)
    {
        HasTakenDamage = true;
        CurrentHp -= amount;
        _hpBar.UpdateHPBar(MaxHp, CurrentHp);
        CameraShakeManager.Instance.CameraShakeFromProfile(_impulseSource, profile);
        // Sound

        PlayRandomDamageSound();

        // Effect
        SpawnDamageParticle(attackDirection);

        Die();
    }


}
