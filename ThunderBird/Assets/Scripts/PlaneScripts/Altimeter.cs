using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Altimeter : MonoBehaviour
{
    [SerializeField] private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Altitude : " + PlaneStick.Altitude;
    }
}
