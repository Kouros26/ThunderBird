using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSmashed : MonoBehaviour
{
    [SerializeField] private Text _text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _text.text = ButtonMash.nbr.ToString();
    }
}
