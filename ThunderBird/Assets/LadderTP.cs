using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LadderTP : MonoBehaviour
{
    public Transform chController;
    bool inside = false;
    public float speedUpDown = 3.2f;
    public CharacterMovement FPSInput;
    private Vector2 movementDir;

    void Start()
    {
        FPSInput = GetComponent<CharacterMovement>();
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = false;
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = true;
            inside = !inside;
        }
    }

    void Update()
    {
        Vector3 direction = new Vector3(movementDir.x, 0.0f, movementDir.y).normalized;

        if (inside == true && direction.x == -1.0f)
        {
            chController.transform.position += Vector3.up / speedUpDown;
        }

        if (inside == true && direction.x == 1.0f)
        {
            chController.transform.position += Vector3.down / speedUpDown;
        }
    }

    public void OnJoystickLadder(InputAction.CallbackContext context)
    {
        movementDir = context.ReadValue<Vector2>().normalized;
    }
}
