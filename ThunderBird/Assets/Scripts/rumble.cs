using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public enum RumblePattern
{
    Constant,
    Pulse,
    Linear
}

public class rumble : MonoBehaviour
{
    private PlayerInput _player;
    private RumblePattern activeRumblePattern;
    private float rumbleDuration;
    private float pulseDuration;
    private float lowA, highA;
    private float rumbleStep;
    private bool isMotorActive = false;

    public void Rumbleconstant(float low, float high, float duration)
    {
        activeRumblePattern = RumblePattern.Constant;
        lowA = low;
        highA = high;
        rumbleDuration = Time.time + duration;
    }

    public void Rumblepulse(float low, float high, float burstTime, float duration)
    {
        activeRumblePattern = RumblePattern.Pulse;
        lowA = low;
        highA = high;
        rumbleStep = burstTime;
        pulseDuration = Time.time + burstTime;
        rumbleDuration = Time.time + duration;
        isMotorActive = true;
        var g = GetGamepad();
        g?.SetMotorSpeeds(lowA, highA);
    }

    public void StopRumble()
    {
        var gamepad = GetGamepad();
        
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0, 0);
        }
    }
    private void Awake()
    {
        _player = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > rumbleDuration)
        {
            StopRumble();
            return;
        }

        var gamepad = GetGamepad();
        if (gamepad == null)
            return;

        switch (activeRumblePattern)
        {
            case RumblePattern.Constant:
                gamepad.SetMotorSpeeds(lowA, highA);
                break;

            case RumblePattern.Pulse:

                if (Time.time > pulseDuration)
                {
                    isMotorActive = !isMotorActive;
                    pulseDuration = Time.time + rumbleStep;
                    
                    if (!isMotorActive)
                    {
                        gamepad.SetMotorSpeeds(0, 0);
                    }

                    else
                    {
                        gamepad.SetMotorSpeeds(lowA, highA);
                    }
                }

                break;

            case RumblePattern.Linear:
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        StopRumble();
    }

    private Gamepad GetGamepad()
    {
        return Gamepad.all.FirstOrDefault(g => _player.devices.Any(d => d.deviceId == g.deviceId));
    }    
}
