using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECLAIR : MonoBehaviour
{
    public GameObject Eclair;
    bool flash;

    // Start is called before the first frame update
    void Start()
    {
        Eclair.SetActive(false);
        StartCoroutine(returnFlash());
    }
    private void Update()
    {
        if (flash)
        {
            flash = false;
            StartCoroutine(Flash());
        }
        else
        {
            return;
        }
    }

   IEnumerator returnFlash()
    {
        int mixedReality = Random.Range(2, 15);
        yield return new WaitForSeconds(mixedReality);
        flash = true;
    }

    IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.04f);
        Eclair.SetActive(true);


        yield return new WaitForSeconds(0.05f);
        Eclair.SetActive(false);

        yield return new WaitForSeconds(0.012f);
        Eclair.SetActive(true);

        yield return new WaitForSeconds(0.013f);
        Eclair.SetActive(false);

        yield return new WaitForSeconds(0.024f);
        Eclair.SetActive(true);

        yield return new WaitForSeconds(0.025f);
        Eclair.SetActive(false);
        StartCoroutine(returnFlash());
    }



    // Update is called once per frame

}
