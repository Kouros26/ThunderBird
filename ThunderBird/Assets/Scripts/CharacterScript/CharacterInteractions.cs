using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class CharacterInteractions : MonoBehaviour
{
    public static bool interacting;
    [SerializeField] private bool interactible = HandHitbox.interactible;
    [SerializeField] private rumble rumble;
    public ButtonMash button;
    private bool PlayerOne, PlayerTwo;

    [Header ("Dragon")]
   // ParticleSystem particles;
    private bool dragon;

    [Header("ResetEngine")] private bool Engine1, Engine2;

    [Header("Water&Fuel")]
    private bool water, fuel, emptybucket, followWater, fuelpumps;
    private GameObject BucketWater, BucketFuel, BucketEmpty;
    public bool hasObjectWater, hasObjectFuel;

    public GameObject player, playerHands, item;
    private bool pickable, follow;
    public bool hasObject = false;
    public bool bucketFilled = false;

    public AudioManagerScript sceneAudio; 
    public CaressTheDragon caressTheDragonScript;
    public EventManagerScript eventManagerScript;
    public static bool fillWater;
    public static bool fillFuel;


    // Start is called before the first frame update
    void Start()
    {
        sceneAudio = GameObject.Find("AudioManager").GetComponent<AudioManagerScript>();
        caressTheDragonScript = GameObject.Find("plaques_chariot").GetComponent<CaressTheDragon>();
        eventManagerScript = GameObject.Find("SCENE").GetComponent<EventManagerScript>();
    }

    void FixedUpdate()
    {
        if (!follow)
        {
            return;
        }
        if(follow)
        {
            item.transform.position = playerHands.transform.position;
            pickable = false;
        }
        //if (!followWater) return;
        //BucketWater.transform.position = playerHands.transform.position;
        //water = false;

    }

    void Update()
    {
        Setup();
        if (!interacting || !EventScript.isOccupied)
        {
            button.enabled = false;
        };
        if (CharacterMovement.moving)
            interacting = false; HandHitbox.interactible = false;

        if (interacting || EventScript.isOccupied)
        {
            button.enabled = true;
            button.Update();
        }

        

    }

    public void ResetEngine(InputAction.CallbackContext context)
    {
        bool temp = context.performed;

        if (temp & Engine1)
        {
            
        }
    }

    public void Dragon(InputAction.CallbackContext context)
    {
        bool temp = context.performed;

        if (temp && dragon && eventManagerScript.alreadyPet)
        {
            //dragon = false;
            //HandHitbox.dragon = false;
            caressTheDragonScript.love = true;
            print(caressTheDragonScript.love);

            //Debug.Log("Clique!!!!!!");
        }
        else
        {
            return;
            //caressTheDragonScript.love = false;
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
                AudioManagerScript.clip = sceneAudio.Grab;
                AudioManagerScript.PlayAudio();
                hasObject = true;
            }
        }

        else
        {
            Drop();
        }
    }

    public void HasObjectEmptyToWater(InputAction.CallbackContext context)
    {
        if (hasObject && fuelpumps && !bucketFilled)
        {
            Debug.Log("L'eau c'est la vie meme dans un sceau");
            AudioManagerScript.clip = sceneAudio.EssenceFilling;
            AudioManagerScript.PlayAudio();
            hasObjectWater = true;
            bucketFilled = true;
            fillWater = true;
            eventManagerScript.Fill();
            eventManagerScript.requirement = 1;
            //hasObjectFuel = false;
        }
    }
    public void HasObjectEmptyToFuel(InputAction.CallbackContext context)
    {
        if (hasObject && fuelpumps && !bucketFilled)
        {
            Debug.Log("Du fuel dans le malibu et dans le sceau");
            //hasObjectWater = false;
            AudioManagerScript.clip = sceneAudio.EssenceFilling;
            AudioManagerScript.PlayAudio();
            hasObjectFuel = true;
            bucketFilled = true;
            fillFuel = true;
            eventManagerScript.Fill();
            eventManagerScript.requirement = 2;
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
        fuelpumps = HandHitbox.fuelpumps;
    }

    public void Drop()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        follow = false;
        hasObject = false;
        bucketFilled = false;
        hasObjectWater = false;
        hasObjectFuel = false;
        eventManagerScript.requirement = 0;
        fillWater = false;
        fillFuel = false;
        eventManagerScript.Fill();
    }
}
