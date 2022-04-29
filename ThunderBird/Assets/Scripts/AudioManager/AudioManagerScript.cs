using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private AudioClip airplaneAmbient, thunderStorm;

    [Header("Character")]
    [SerializeField] private AudioClip footSteps, grab;

    [Header("Event/Mission")]
    [SerializeField] private AudioClip airplaneAlarmGeneral, airplaneFreeFall, airplaneTurbulence, fastenSeatBelt, blackout, doorClose, doorOpen;
    [SerializeField] private AudioClip dragonContent, dragonNotContent, essenceFilling, fireSoundEffect, leverSwitch, thunderClap;

    public AudioClip MainAlarm { get => airplaneAlarmGeneral; }
    public AudioClip AmbientSound { get => airplaneAmbient; }
    public AudioClip AirplaneFall { get => airplaneFreeFall; }  
    public AudioClip Turbulence { get => airplaneTurbulence ; }
    public AudioClip BlackOut { get => blackout; }
    public AudioClip DoorClose { get => doorClose; }
    public AudioClip DoorOpen { get => doorOpen; }
    public AudioClip DragonContent { get => dragonContent; }
    public AudioClip DragonNotContent { get => dragonNotContent; }
    public AudioClip EssenceFilling { get => essenceFilling; }
    public AudioClip FastenSeatBell { get => fastenSeatBelt; }
    public AudioClip FireSoundEffect { get => fireSoundEffect; }
    public AudioClip FootSteps { get => footSteps;  }
    public AudioClip Grab { get => grab; }
    public AudioClip Switch { get => leverSwitch; }
    public AudioClip ThunderClap { get => thunderClap; }
    public AudioClip ThunderStorm { get => thunderStorm; }

    public static AudioSource audioPlane;
    public static AudioClip clip;

    void Start()
    {
        audioPlane = GetComponent<AudioSource>();
    }


    public static void PlayAudio()
    {
        audioPlane.PlayOneShot(clip);
    }
}
