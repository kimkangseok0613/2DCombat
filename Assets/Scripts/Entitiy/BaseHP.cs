using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public abstract class BaseHP : MonoBehaviour ,Idamagable
{
    //체력
    [field: SerializeField] public int CurrentHp { get; set; }
    [field: SerializeField] public int MaxHp { get; set; } = 3;
    public bool HasTakenDamage { get; set; } // true 일때 어떤상황으로 정의할지

    [SerializeField] private AudioClip damageClip;
    public string HurtClipName;

    [SerializeField] private ParticleSystem _damageParticle;

    protected virtual void Start()
    {
        CurrentHp = MaxHp;      
    }

    public abstract void Damage(int amount, Vector2 attackDirection);

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
    protected void SpawnDamageParticle(Vector2 attackDirection) // Particle
    {
        if (_damageParticle == null)
        {
            return;
        }

        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, -attackDirection);

        Instantiate(_damageParticle, transform.position, spawnRotation);
    }
}
