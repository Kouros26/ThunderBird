using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaressTheDragon : MonoBehaviour
{
    public GameObject Particle;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("JAIDITAMOUR");
        Particle.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider Joueur)
    {
        if (Joueur.gameObject.tag == "Player")
        {
            Debug.Log("JMOUR");

        }
    }
}
