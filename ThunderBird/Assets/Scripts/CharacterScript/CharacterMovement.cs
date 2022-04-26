using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed;
    private Vector2 movementDir;
    public static Transform pos;
    public static bool moving;
    Animator playerAnimations;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform;
        playerAnimations = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-movementDir.y * Time.deltaTime * PlayerSpeed, 0.0f, movementDir.x * Time.deltaTime * PlayerSpeed);
    }

    public void OnJoystick(InputAction.CallbackContext context)
    {
        playerAnimations.SetBool("Move", true);
        movementDir = context.ReadValue<Vector2>();
        moving = true;
        OnJoystickLeft(movementDir);
    }

    public void OnJoystickLeft(Vector2 vec)
    {
        if (vec == Vector2.zero)
            playerAnimations.SetBool("Move", false);
            moving = false;
    }
}
