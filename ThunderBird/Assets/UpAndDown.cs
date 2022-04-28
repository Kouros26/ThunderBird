using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    [SerializeField] private float period, amplitude;
    private float x = -Mathf.PI/2;
    private Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = spawn + new Vector3(0.0f, Mathf.Sin(x) + 1, 0.0f) * amplitude;
        x += period;
    }
}
