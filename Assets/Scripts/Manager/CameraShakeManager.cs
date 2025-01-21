using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using MyNamespace;
using UnityEngine;

public class CameraShakeManager : SingleTon<CameraShakeManager>
{
    [SerializeField] private float globalshakeForce = 1.0f;
    [SerializeField] private CinemachineImpulseListener _impulseListener;

    private CinemachineImpulseDefinition _impulseDefinition;

    public void Camerashake(CinemachineImpulseSource impulsesourse)
    {
        // if(impulsesourse != null) == impulsesourse?.GenerateImpulseWithForce(globalshakeForce);
        impulsesourse?.GenerateImpulseWithForce(globalshakeForce);
    }

    public void CameraShakeFromProfile(CinemachineImpulseSource impulsesourse, ScreenShakeSO profile)
    {
        SetupScreenShake(impulsesourse, profile);

        impulsesourse?.GenerateImpulseWithForce(profile.impactForce);
    }

    private void SetupScreenShake(CinemachineImpulseSource _impulseSource, ScreenShakeSO profile)
    {
        _impulseDefinition = _impulseSource.m_ImpulseDefinition;

        _impulseDefinition.m_ImpulseDuration = profile.impactForce;
        _impulseDefinition.m_CustomImpulseShape = profile.impulseCurve;

        _impulseSource.m_DefaultVelocity = profile.defaultVelocity;

        _impulseListener.m_ReactionSettings.m_AmplitudeGain = profile.listenerAmplitude;
        _impulseListener.m_ReactionSettings.m_FrequencyGain = profile.listenerFrequency;
        _impulseListener.m_ReactionSettings.m_Duration = profile.listenerDuration;

    }
}
