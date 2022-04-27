using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteractions : MonoBehaviour
{
    public static bool interacting;
    [SerializeField] private bool interactible = HandHitbox.interactible;

    [Header ("Dragon")]
    public ParticleSystem heart;
    public bool includeChildren = true;
    bool dragon = false;

    [Header("ResetEngine")]
    bool Engine1 = false;
    bool Engine2 = false;

    public GameObject player;
    public GameObject playerHands;
    GameObject item;
    bool pickable = false, follow = false, hasObject = false;

    // Start is called before the first frame update
    void Start()
    {
        heart.Stop(includeChildren);
    }

    void FixedUpdate()
    {
        if (!follow) return;
        item.transform.position = playerHands.transform.position;
        pickable = false;
    }

    // Update is called once per frame
    void Update()
    {
        Setup();
        if (!interacting) return;
        if (CharacterMovement.moving)
            interacting = false; HandHitbox.interactible = false;

    }

    public void ResetEngine(InputAction.CallbackContext context)
    {
        if (Engine1 && Engine2)
        {
            print("resetengine Bordelcamarche");
        }
    }

    public void Dragon(InputAction.CallbackContext context)
    {
        if (dragon)
        {
            heart.Play(includeChildren);
        }
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        bool temp = context.performed;

        if (temp && interactible)
        {
            interacting = true;
            return;
        }

        if (!hasObject)
        {
            if (pickable)
            {
                item.GetComponent<Rigidbody>().useGravity = false;
                follow = true;
                hasObject = true;
            }
        }

        else
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            follow = false;
            hasObject = false;
        }
    }

    private void Setup()
    {
        interactible = HandHitbox.interactible;
        pickable = HandHitbox.pickable;
        item = HandHitbox.item;
        Engine1 = HandHitbox.Engine1;
        Engine2 = HandHitbox.Engine2;
        dragon = HandHitbox.dragon;
    }
}
