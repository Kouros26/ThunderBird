using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteractions : MonoBehaviour
{
    public static bool interacting;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!interacting) return;
        if (CharacterMovement.moving)
            interacting = false;
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        bool temp = context.performed;
        
        if (temp)
            interacting = true;
    }
}
