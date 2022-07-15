using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I collide with " + collision.gameObject.name);
    }
}
