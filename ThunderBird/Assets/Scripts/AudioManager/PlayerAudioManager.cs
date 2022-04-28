using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private AudioClip airplaneAmbient, thunderStorm;

    [Header("Character")]
    [SerializeField] private AudioClip  death, footSteps, grab;

    [Header("Event/Mission")]
    [SerializeField] private AudioClip airplaneAlarmGeneral, airplaneFreeFall, airplaneTurbulence, fastenSeatBelt, blackout, depressurization, equipMask, doorClose, doorOpen;
    [SerializeField] private AudioClip dragonContent, dragonNotContent, essenceFilling, fireSoundEffect, radioNoise, radioTalking, leverSwitch, thunderClap;

    public AudioClip MainAlarm { get => airplaneAlarmGeneral; }
    public AudioClip AmbientSound { get => airplaneAmbient; }
    public AudioClip AirplaneFall { get => airplaneFreeFall; }  
    public AudioClip Turbulence { get => airplaneTurbulence ; }
    public AudioClip BlackOut { get => blackout; }
    public AudioClip Death { get => death; }
    public AudioClip Depressurization { get => depressurization; }
    public AudioClip DoorClose { get => doorClose; }
    public AudioClip DoorOpen { get => doorOpen; }
    public AudioClip DragonContent { get => dragonContent; }
    public AudioClip DragonNotContent { get => dragonNotContent; }
    public AudioClip EquipMask { get => equipMask; }
    public AudioClip EssenceFilling { get => essenceFilling; }
    public AudioClip FastenSeatBell { get => fastenSeatBelt; }
    public AudioClip FireSoundEffect { get => fireSoundEffect; }
    public AudioClip FootSteps { get => footSteps;  }
    public AudioClip Grab { get => grab; }
    public AudioClip RadioNoise { get => radioNoise; }
    public AudioClip RadioTalking { get => radioTalking; }
    public AudioClip Switch { get => leverSwitch; }
    public AudioClip ThunderClap { get => thunderClap; }
    public AudioClip ThunderStorm { get => thunderStorm; }

    [SerializeField] private AudioSource audioPlane;
    public AudioClip clip;

    void Start()
    {
        audioPlane = GetComponent<AudioSource>();
    }


    public void PlayAudio()
    {
        audioPlane.PlayOneShot(clip);
    }
}
