using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Altimeter : MonoBehaviour
{
    [SerializeField] private Text _text;
    private Color _color;
    [SerializeField] private float gradiant;

    // Start is called before the first frame update
    void Start()
    {
        _color.r = 1;
        _color.g = 1;
        _color.b = 1;
        _color.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gradiant = (PlaneStick.Altitude / PlaneStick.AltitudeMax);

        _color.g = gradiant;
        _color.b = gradiant;

        _text.color = _color;

        _text.text = "Altitude : " + PlaneStick.Altitude + "m";
    }
}
