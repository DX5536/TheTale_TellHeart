using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickableObjects : MonoBehaviour
{
    //Reference to the object's rigid body
    private Rigidbody rb;

    public Rigidbody Rb
    {
        get { return rb; }
        set { rb = value; }
    }

    private void Awake()
    {
        //Get the component when awake
        rb = GetComponent<Rigidbody>();
    }
}
