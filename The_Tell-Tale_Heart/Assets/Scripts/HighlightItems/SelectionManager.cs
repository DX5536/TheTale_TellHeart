using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private SelectMaterialData selectMaterialData;

    //[Header("DEBUGGING Variables")]
    private Transform mySelectionDEBUG;

    private SelectableObject_Story mySelectableObject_Story;
    private QuestObject_Story myQuestCollider_Story;
    private OriginalMaterial originalMaterial;

    // Update is called once per frame
    void Update()
    {
        UpdateDefaultMaterial();

        HighlightSelectedObject();

        //Check if the object which hit the ray is highlighited
        if (selectMaterialData.IsObjectHighlighted == true)
        {
            mySelectableObject_Story = selectMaterialData._Selection.GetComponent<SelectableObject_Story>();
            myQuestCollider_Story = selectMaterialData._Selection.GetComponent<QuestObject_Story>();
            mySelectionDEBUG = selectMaterialData._Selection;

            if (mySelectableObject_Story.enabled == false)
            {
                //This step is to avoid Error when a GO without _Story yet has SelectableTag
                //Should not be here in the first place
                Debug.Log("This Object's Story is disabled");
                return;
            }

            else
            {
                CheckSelectableObject_StoryAndQuestCollider_Story();
            }

            //Debug.Log("Selection is " + selectMaterialData._Selection.name);
        }
    }

    //This methode will temporary save before material so when ray doesn't hit Object anymore -> old material will be pasted back
    void UpdateDefaultMaterial()
    {
        //Assign a ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Object being hit
        RaycastHit hit;

        //Highlight Ray = pickup ray to avoid system conflicts of items on the floor
        if (Physics.Raycast(ray, out hit, 4f))
        {
            var selection = hit.transform;

            if (selection.CompareTag(selectMaterialData.SelectableTag))
            {
                //Grab the current material on Object
                GameObject currentMaterialObject = hit.collider.gameObject;
                originalMaterial = currentMaterialObject.GetComponent<OriginalMaterial>();

                //Check first if the SelectableGO even has OriginalMaterial.enabled
                if(originalMaterial.enabled == false)
                {
                    Debug.Log("ERROR Selectable in OG Material of " + selection.name);
                    return;
                }

                else
                {
                    if (originalMaterial == null)
                    {
                        selectMaterialData.SavedDefaultMaterial = selectMaterialData.DefaultMaterial;
                    }

                    else
                    {
                        selectMaterialData.SavedDefaultMaterial = originalMaterial.OgMaterial;
                    }
                }
            }

            //If Object is special and required special highlight
            else if (selection.CompareTag(selectMaterialData.SelectableSpecialTag))
            {
                GameObject currentMaterialObject = hit.collider.gameObject;
                originalMaterial = currentMaterialObject.GetComponent<OriginalMaterial>();

                //Check first if the SelectableGO even has OriginalMaterial.enabled
                if (originalMaterial.enabled == false)
                {
                    Debug.Log("ERROR SpecialSelectable in OG Material of " + selection.name);
                    return;
                }

                else
                {
                    if (originalMaterial == null)
                    {
                        selectMaterialData.SavedDefaultMaterial = selectMaterialData.DefaultMaterial;
                    }

                    else
                    {
                        //Going back to og
                        selectMaterialData.SavedDefaultMaterial = originalMaterial.OgMaterial;
                    }
                }
            }

        }
    }

    //Method of highlight object
    void HighlightSelectedObject()
    {
        //De-selection -> GO goes back to defaultMaterial
        if (selectMaterialData._Selection != null)
        {
            var selectionRenderer = selectMaterialData._Selection.GetComponent<Renderer>();
            selectionRenderer.material = selectMaterialData.SavedDefaultMaterial; //set material to default material
            selectMaterialData._Selection = null;

            selectMaterialData.IsObjectHighlighted = false;
        }

        //Assign a ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Object being hit
        RaycastHit hit;

        //check if Ray hit the object -> Selection
        if (Physics.Raycast(ray, out hit, 4f)) ////Ray-length = Arm-length
        {
            //Selected object
            var selection = hit.transform;

            //Check through tag if GO can be highlighted
            if (selection.CompareTag(selectMaterialData.SelectableTag))
            {
                //First Check if GO even has OG Material.enabled > No: Cant be Highlight
                if (originalMaterial.enabled == false)
                {
                    Debug.Log("This GO " + selection.name + "cant be highligh despite have Tag");
                    return;
                }

                else
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();

                    //check if selected Object doesn't NOT have a renderer
                    if (selectionRenderer != null)
                    {
                        //if true -> set default Material to highlightMaterial
                        selectionRenderer.material = selectMaterialData.HighlightMaterial;

                        selectMaterialData.IsObjectHighlighted = true;
                    }

                    selectMaterialData._Selection = selection;
                }
            }

            //check through Tags if it's specialObject
            else if (selection.CompareTag(selectMaterialData.SelectableSpecialTag))
            {
                //First Check if GO even has OG Material.enabled > No: Cant be Highlight
                if (originalMaterial.enabled == false)
                {
                    Debug.Log("This GO " + selection.name + "cant be highligh despite have Tag");
                    return;
                }

                else
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();

                    //check if selected Object doesn't NOT have a renderer
                    if (selectionRenderer != null)
                    {
                        //if true -> set default Material to highlightSpecialMaterial
                        selectionRenderer.material = selectMaterialData.HighlightSpecialMaterial;

                        selectMaterialData.IsObjectHighlighted = true;
                    }

                    selectMaterialData._Selection = selection;
                }
            }
        }
    }

    void CheckSelectableObject_StoryAndQuestCollider_Story()
    {
        //If an object has both story and quest
        if (mySelectableObject_Story == true && myQuestCollider_Story == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                myQuestCollider_Story.UpdateObjectQuest();
                mySelectableObject_Story.ShowObjectStory();

                Debug.Log("(Quest)Story_Object");
            }

        }

        //If selected Object is highlighted -> Check if the SelectableObject_Story Component exist
        else if (mySelectableObject_Story == true)
        {
            //If it exist
            //And then player click l.mouse
            if (Input.GetMouseButtonDown(0))
            {
                //Execute the public method to show the story in the highlightable Object
                mySelectableObject_Story.ShowObjectStory();
                Debug.Log("Story_Object");
            }
        }

        //If the highlighted object is a QuestUpdater instead
        else if (myQuestCollider_Story == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Execute the public method to update Quest in the highlightable Object
                myQuestCollider_Story.UpdateObjectQuest();

                Debug.Log("Quest_Object");
            }
        }

        //If an object has NOTHING
        else if (null == mySelectableObject_Story || myQuestCollider_Story)
        {
            //If an object has nothing yet selectable > Bug
            Debug.Log("This object is wrong > ERROR");
            return;
        }
    }
}
