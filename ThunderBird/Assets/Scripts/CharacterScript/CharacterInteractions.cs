using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInteractions : MonoBehaviour
{
    public static bool interacting;
    [SerializeField] private bool interactible;

    [Header ("Dragon")]
    public ParticleSystem heart;
    public bool includeChildren = true;
    bool dragon = false;

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
        if (follow)
        {
            item.transform.position = playerHands.transform.position;
            pickable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!interacting) return;
        if (CharacterMovement.moving)
            interacting = false; interactible = false;

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

    public void OnCollisionEnter(Collision collision)
    {
        interactible = collision.gameObject.tag == "Interactible" ? true : false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup")
        {
            pickable = true;
            item = other.gameObject;
        }

        if (other.tag == "Dragon")
        {
            dragon = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "pickup")
        {
            pickable = false;
        }

        if (other.tag == "Dragon")
        {
            dragon = false;
        }

    }
}
