using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private float PlayerSpeed;
    [SerializeField] private float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;
    private Vector2 movementDir;
    public static Transform pos;
    public static bool moving;
    public Animator playerAnimations;

    public bool paused = false;
    public bool checkForMove = false;
    public EventScript eventScript;


    // Start is called before the first frame update
    void Start()
    {
        pos = transform;
        playerAnimations = gameObject.GetComponent<Animator>();
        eventScript = GetComponent<EventScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!paused)
        {
            Vector3 direction = new Vector3(movementDir.x, 0.0f, movementDir.y).normalized;

            if (direction.magnitude > 0.0f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                controller.Move(direction * PlayerSpeed * Time.deltaTime);
                moving = true;
            }

            else moving = false;

            controller.SimpleMove(direction);
        }

    }

    public void OnJoystick(InputAction.CallbackContext context)
    {
        if (checkForMove)
        {
            checkForMove = false;
            paused = false;
            EventScript.isOccupied = false;
            StartCoroutine(WaitForReset());
            playerAnimations.SetBool("Sit", false);
        }

        if (!paused)
        {
            playerAnimations.SetBool("Move", true);
            movementDir = context.ReadValue<Vector2>().normalized;
            OnJoystickLeft(movementDir);
        }
    }

    public void OnJoystickLeft(Vector2 vec)
    {
        if (vec == Vector2.zero)
            playerAnimations.SetBool("Move", false);
    }

    IEnumerator WaitForReset()
    {
        yield return new WaitForSeconds(15);
        EventScript.CockpitMission();
    }
}
