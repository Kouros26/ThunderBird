using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonMash : MonoBehaviour
{
    public float mashDelay = .5f;
    public static float mash;
    [SerializeField] private bool pressed;
    public static int nbr;
    private float timer = 0;
    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        mash = mashDelay;
        GameObject temp = GameObject.Find("ButtonSmashed");
        _text = temp.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mash -= Time.deltaTime;
        timer += Time.deltaTime;

        if (pressed)
        {
            mash = mashDelay;
            timer = 0;
            nbr++;
            _text.text = "SMASH X !";
        }

        //Debug.Log(timer);
        if (mash <= 0 && timer > 2)
        {
            PlaneStick.Punishment();
            timer = 0;
            _text.text = "OUCH !";
        }
    }

    public void OnButton(InputAction.CallbackContext context)
    {
        pressed = context.performed;
    }
}
