using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed;
    private Vector2 movementDir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-movementDir.y * Time.deltaTime * PlayerSpeed, 0.0f, movementDir.x * Time.deltaTime * PlayerSpeed);
    }

    public void OnJoystick(InputAction.CallbackContext context)
    {
        movementDir = context.ReadValue<Vector2>();
    }
}
