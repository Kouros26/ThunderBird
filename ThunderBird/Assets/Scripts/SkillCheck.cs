using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    public bool isTouching = false;
    //public Animator jaugeAnim;

    // Start is called before the first frame update
    void Start()
    {
        //jaugeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkillCheckStart()
    {
        
    }

    public void SkillCheckStop()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "QTE")
        {
            isTouching = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "QTE")
        {
            isTouching = false;
        }
    }

}
