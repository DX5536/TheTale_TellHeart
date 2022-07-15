using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplicatedSelectionManager : MonoBehaviour
{
    [SerializeField]
    private ComplicatedSelectMaterialData selectComplicatedMaterialData;

    [SerializeField]
    private Renderer[] selectionRenderer;

    // Update is called once per frame
    void Update()
    {
        UpdateDefaultComplicatedMaterial();

        HighlightComplicatedSelectedObject();

        //Check if the object which hit the ray is highlighited
        if (selectComplicatedMaterialData.IsObjectHighlighted == true)
        {
            //If an object has both story and quest
            if (selectComplicatedMaterialData._Selection.GetComponentInChildren<SelectableObject_Story>() == true && selectComplicatedMaterialData._Selection.GetComponentInChildren<QuestObject_Story>() == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    selectComplicatedMaterialData._Selection.GetComponentInChildren<QuestObject_Story>().UpdateObjectQuest();
                    selectComplicatedMaterialData._Selection.GetComponentInChildren<SelectableObject_Story>().ShowObjectStory();
                }

            }

                //If selected Object is highlighted -> Check if the SelectableObject_Story Component exist
            else if (selectComplicatedMaterialData._Selection.GetComponentInChildren<SelectableObject_Story>() == true)
            {
                //If it exist
                //And then player click l.mouse
                if (Input.GetMouseButtonDown(0))
                {
                    //Execute the public method to show the story in the highlightable Object
                    selectComplicatedMaterialData._Selection.GetComponentInChildren<SelectableObject_Story>().ShowObjectStory(); 
                }
            }

            //If the highlighted object is a QuestUpdater instead
            else if (selectComplicatedMaterialData._Selection.GetComponentInChildren<QuestObject_Story>() == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //Execute the public method to update Quest in the highlightable Object
                    selectComplicatedMaterialData._Selection.GetComponentInChildren<QuestObject_Story>().UpdateObjectQuest();
                }
            }

        }
    }

    //This methode will temporary save before material so when ray doesn't hit Object anymore -> old material will be pasted back
    void UpdateDefaultComplicatedMaterial()
    {
        //Assign a ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Object being hit
        RaycastHit hit;

        //Highlight Ray = pickup ray to avoid system conflicts of items on the floor
        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            //The object being hit here is parent
            var selection = hit.transform;

            if (selection.CompareTag(selectComplicatedMaterialData.SelectableTag))
            {
                //Grab the current material on Object
                GameObject currentMaterialObject = hit.collider.gameObject;
                ComplicatedOriginalMaterial originalMaterial = currentMaterialObject.GetComponent<ComplicatedOriginalMaterial>();

                if (originalMaterial != null)
                {
                    for (int i = 0; originalMaterial.OgChildMaterials.Length > 0; i++)
                    {
                        selectComplicatedMaterialData.SavedDefaultMaterials[i] = selectComplicatedMaterialData.DefaultMaterial;
                        //selectComplicatedMaterialData.SavedDefaultMaterials[i] = originalMaterial.OgChildMaterials[i];
                    }
                    
                }

                else
                {
                    //Go back to OG
                    for (int i = 0 ; originalMaterial.OgChildMaterials.Length > 0 ; i++)
                    {
                        selectComplicatedMaterialData.SavedDefaultMaterials[i] = originalMaterial.OgChildMaterials[i];
                    }
                }

            }

            //If Object is special and required special highlight
            /*else if (selection.CompareTag(selectComplicatedMaterialData.SelectableSpecialTag))
            {
                GameObject currentMaterialObject = hit.collider.gameObject;
                ComplicatedOriginalMaterial originalMaterial = currentMaterialObject.GetComponent<ComplicatedOriginalMaterial>();

                if (originalMaterial != null)
                {
                    for (int i = 0 ; originalMaterial.OgChildMaterials.Length > 0 ; i++)
                    {
                        //selectComplicatedMaterialData.SavedDefaultMaterials[i] = selectComplicatedMaterialData.DefaultMaterial;
                        selectComplicatedMaterialData.SavedDefaultMaterials[i] = originalMaterial.OgChildMaterials[i];
                    }

                }

                else
                {
                    //Go back to OG
                    for (int i = 0 ; originalMaterial.OgChildMaterials.Length > 0 ; i++)
                    {
                        //selectComplicatedMaterialData.SavedDefaultMaterials[i] = originalMaterial.OgChildMaterials[i];
                    }
                }
            }*/

        }
    }

    //Method of highlight object
    void HighlightComplicatedSelectedObject()
    {
        //De-selection -> GO goes back to defaultMaterial
        if (selectComplicatedMaterialData._Selection != null)
        {
            //Get all the Renderer components
            var selectionRenderer = selectComplicatedMaterialData._Selection.GetComponents<Renderer>();
            for (int i = 0 ; selectComplicatedMaterialData.SavedDefaultMaterials.Length > 0 ; i++)
            {
                selectionRenderer[i].material = selectComplicatedMaterialData.SavedDefaultMaterials[i];
            }
             //set material to default material
            selectComplicatedMaterialData._Selection = null;

            selectComplicatedMaterialData.IsObjectHighlighted = false;
        }

        //Assign a ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Object being hit
        RaycastHit hit;

        //check if Ray hit the object -> Selection
        if (Physics.Raycast(ray, out hit, 2.5f)) ////Ray-length = Arm-length
        {
            //Selected object
            var selection = hit.transform;

            //Check through tag if GO can be highlighted
            if (selection.CompareTag(selectComplicatedMaterialData.SelectableTag))
            {
                //Go through all the children of the HL object
                for (int h = 0 ; selectComplicatedMaterialData.SavedDefaultMaterials.Length > h ; h++)
                {
                    //And save all the children (as GO) of this GO in an array -> GameObject[]
                    selectionRenderer[h] = selection.GetComponentInChildren<Renderer>();
                }

                //check if selected Object does have a renderer
                if (selectionRenderer != null)
                {
                    //if true -> go through the array -> set everything to default Material to highlightMaterial
                    for (int i = 0 ; selectionRenderer.Length > 0 ; i++)
                    {
                        selectionRenderer[i].material = selectComplicatedMaterialData.HighlightMaterial;
                    }


                    selectComplicatedMaterialData.IsObjectHighlighted = true;
                }

                selectComplicatedMaterialData._Selection = selection;
            }

            //check through Tags if it's specialObject
            /*else if (selection.CompareTag(selectComplicatedMaterialData.SelectableSpecialTag))
            {
                //Go through all the children of the HL object
                for (int h = 0 ; selectComplicatedMaterialData.SavedDefaultMaterials.Length > h ; h++)
                {
                    //And save all the children (as GO) of this GO in an array -> GameObject[]
                    selectionRenderer[h] = selection.GetChild(h).GetComponentInChildren<Renderer>();
                }

                //check if selected Object does have a renderer
                if (selectionRenderer != null)
                {
                    //if true -> go through the array -> set everything to default Material to highlightMaterial
                    for (int i = 0 ; selectionRenderer.Length > 0 ; i++)
                    {
                        selectionRenderer[i].material = selectComplicatedMaterialData.HighlightSpecialMaterial;
                    }

                    selectComplicatedMaterialData._Selection = selection;
                }

            }*/
        }
    }
}
