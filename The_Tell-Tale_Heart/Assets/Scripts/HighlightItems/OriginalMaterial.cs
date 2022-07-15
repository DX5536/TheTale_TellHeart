using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalMaterial : MonoBehaviour
{
    private Material ogMaterial;

    public Material OgMaterial
    {
        get { return ogMaterial; }
        set { ogMaterial = value; }
    }

    //GameObject grab their own current Material and save it in ogMaterial
    private void Start()
    {
        var objectOwnRenderer = GetComponent<Renderer>();
        ogMaterial = objectOwnRenderer.material;
    }
}