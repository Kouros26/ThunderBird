using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteractions : MonoBehaviour
{
    public static bool interacting;
    [SerializeField] private bool interactible = HandHitbox.interactible;

    [Header ("Dragon")]
    ParticleSystem particles;
    public bool includeChildren = true;
    bool dragon = false, love = false;

    [Header("ResetEngine")]
    bool Engine1 = false;
    bool Engine2 = false;

    [Header("Water&Fuel")]
    bool water = false, fuel = false, emptybucket = false, followWater = false;
    GameObject BucketEmpty;
    GameObject BucketWater;
    GameObject BucketFuel;

    public GameObject player;
    public GameObject playerHands;
    GameObject item;
    bool pickable = false, follow = false, hasObject = false;

    // Start is called before the first frame update
    void Start()
    {
        particles.Stop(includeChildren);
    }

    void FixedUpdate()
    {
        if (!follow) return;
        item.transform.position = playerHands.transform.position;
        pickable = false;
        if (!followWater) return;
        BucketWater.transform.position = playerHands.transform.position;
        water = false;
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
            Debug.Log("Clique!!!!!!");
            particles.Stop(includeChildren);

            love = true;
        }
        else
        {
            particles.Stop(includeChildren);

            love = false;
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

    public void Water(InputAction.CallbackContext context)
    {
        bool temp = context.performed;

        if (temp && interactible)
        {
            interacting = true;
            return;
        }

        if (!hasObject)
        {
            if (water)
            {
                BucketWater.GetComponent<Rigidbody>().useGravity = false;
                followWater = true;
                hasObject = true;
            }
        }

        else
        {
            BucketWater.GetComponent<Rigidbody>().useGravity = true;
            followWater = false;
            hasObject = false;
        }
    }

    public void Fuel(InputAction.CallbackContext context)
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
        water = HandHitbox.water;
        fuel = HandHitbox.fuel;
        emptybucket = HandHitbox.emptybucket;
        BucketWater = HandHitbox.BucketWater;
        BucketFuel = HandHitbox.BucketFuel;
        BucketEmpty = HandHitbox.BucketEmpty;

    }
}
