using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectMaterialData", menuName = "HighlightItems/ScriptableObject/CreateSelectMaterialData", order = 1)]

public class SelectMaterialData : ScriptableObject
{
    //Differenciate Selectable and non-Selectable through Tags
    [SerializeField]
    private string selectableTag; //now all GO with this tag can be highlight ^^

    //Special Object with special highlight
    [SerializeField]
    private string selectableSpecialTag;

    //Assign highlightMaterial
    [SerializeField]
    private Material highlightMaterial;

    //Assign highlightSpecialMaterial
    [SerializeField]
    private Material highlightSpecialMaterial;

    [SerializeField]
    private Material defaultMaterial;

    [SerializeField]
    private Material savedDefaultMaterial;

    //Save current selection
    private Transform _selection;

    private bool isObjectHighlighted;


    //Property for the private variables
    public string SelectableTag 
    { get { return selectableTag; } 
      set { selectableTag = value; } 
    }

    public string SelectableSpecialTag 
    { get { return selectableSpecialTag; } 
      set { selectableSpecialTag = value; } 
    }

    public Material HighlightMaterial
    {
        get { return highlightMaterial; }
        set { highlightMaterial = value; }
    }

    public Material HighlightSpecialMaterial
    {
        get { return highlightSpecialMaterial; }
        set { highlightSpecialMaterial = value; }
    }

    public Material DefaultMaterial
    {
        get { return defaultMaterial; }
        set { defaultMaterial = value; }
    }

    public Material SavedDefaultMaterial
    {
        get { return savedDefaultMaterial; }
        set { savedDefaultMaterial = value; }
    }

    public Transform _Selection
    {
        get { return _selection; }
        set { _selection = value; }
    }

    public bool IsObjectHighlighted
    {
        get { return isObjectHighlighted; }
        set { isObjectHighlighted = value; }
    }
}
