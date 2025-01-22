using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]

public class EnemyHP : MonoBehaviour, Idamagable
{
    //체력
    [field: SerializeField] public int CurrentHp { get; set; }
    [field: SerializeField] public int MaxHp { get; set; } = 3;
    public bool HasTakenDamage { get; set ; } // true 일때 어떤상황으로 정의할지

    private CinemachineImpulseSource _impulseSource;
    [SerializeField] private ScreenShakeSO profile;

    [SerializeField] private AudioClip damageClip;
    public string HurtClipName;


    private void Start()
    {
        CurrentHp = MaxHp;
        _impulseSource=GetComponent<CinemachineImpulseSource>();
       
    }

    public void Damage(int amount)
    {
        HasTakenDamage = true;
        CurrentHp -= amount;
        CameraShakeManager.Instance.CameraShakeFromProfile(_impulseSource, profile);
        // Sound

        PlayRandomDamageSound();
        
        Die();
    }
    public void PlayRandomDamageSound()
    {
        int randomIndex = UnityEngine.Random.Range(1, 5);
        string clipName = HurtClipName + randomIndex;
        //Debug.Log(randomIndex);
        SoundManager.Instance.PlaySFXFromString(clipName, 1f);
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
