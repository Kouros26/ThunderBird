using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteractions : MonoBehaviour
{
    public static bool interacting;
    [SerializeField] private bool interactible = HandHitbox.interactible;
    [SerializeField] private rumble rumble;

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

    // Start is called before the first frame update
    void Start()
    {
        caressTheDragonScript = GameObject.Find("polySurface154").GetComponent<CaressTheDragon>();
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
        bool temp = context.performed;

        if (temp && dragon)
        {
            caressTheDragonScript.love = true;
            print(caressTheDragonScript.love);
            Debug.Log("Clique!!!!!!");
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
                sceneAudio.clip = sceneAudio.Grab;
                sceneAudio.PlayAudio();
                hasObject = true;
            }
        }

        else
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            follow = false;
            hasObject = false;
            bucketFilled = false;
            hasObjectWater = false;
            hasObjectFuel = false;
        }
    }

    public void HasObjectEmptyToWater(InputAction.CallbackContext context)
    {
        if (hasObject && fuelpumps && !bucketFilled)
        {
            Debug.Log("L'eau c'est la vie meme dans un sceau");
            hasObjectWater = true;
            bucketFilled = true;
            //hasObjectFuel = false;
        }
    }
    public void HasObjectEmptyToFuel(InputAction.CallbackContext context)
    {
        if (hasObject && fuelpumps && !bucketFilled)
        {
            Debug.Log("Du fuel dans le malibu et dans le sceau");
            //hasObjectWater = false;
            hasObjectFuel = true;
            bucketFilled = true;
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
}
