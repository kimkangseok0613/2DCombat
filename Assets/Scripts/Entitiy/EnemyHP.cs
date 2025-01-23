using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]

public class EnemyHP : MonoBehaviour, Idamagable
{
    //ü��
    [field: SerializeField] public int CurrentHp { get; set; }
    [field: SerializeField] public int MaxHp { get; set; } = 3;
    public bool HasTakenDamage { get; set ; } // true �϶� ���Ȳ���� ��������

    private CinemachineImpulseSource _impulseSource;
    [SerializeField] private ScreenShakeSO profile;

    [SerializeField] private AudioClip damageClip;
    public string HurtClipName;

    [SerializeField] private ParticleSystem _damageParticle;


    private void Start()
    {
        CurrentHp = MaxHp;
        _impulseSource=GetComponent<CinemachineImpulseSource>();
       
    }

    public void Damage(int amount, Vector2 attackDirection)
    {
        HasTakenDamage = true;
        CurrentHp -= amount;
        CameraShakeManager.Instance.CameraShakeFromProfile(_impulseSource, profile);
        // Sound

        PlayRandomDamageSound();

        // Effect
        SpawnDamageParticle(attackDirection);         
                              
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
            // gameObject.SetActive(false); // Enemy ������ ��Ȱ��ȭ��
            Destroy(gameObject); // Enemy ������ �����
        }
    }
    private void SpawnDamageParticle(Vector2 attackDirection) // Particle
    {
        if (_damageParticle == null)
        {
            return;
        }

        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, -attackDirection);

        Instantiate(_damageParticle, transform.position, spawnRotation);
    }

}
