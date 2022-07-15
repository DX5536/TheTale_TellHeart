using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    private Camera activeCam;

    [SerializeField]
    private bool useStaticBillboard;

    // Start is called before the first frame update
    void Start()
    {
        activeCam = Camera.main;
    }

    private void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            transform.LookAt(activeCam.transform);
        }
        else
        {
            transform.rotation = activeCam.transform.rotation;
        }
        


        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
