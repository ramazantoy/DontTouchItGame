using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public GameObject karakter;
    Vector3 mesafe;
    void Start()
    {
        mesafe = transform.position - karakter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = karakter.transform.position + mesafe;
    }
}
