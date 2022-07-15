using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastFromLamp : MonoBehaviour
{
    [Header("The Light-GameObject from Lamp")]
    [SerializeField]
    private GameObject lampLight;

    [Header("The target's tag of this Ray")]
    [SerializeField]
    private string targetTag;

    [Header("Calculate ray.direction with 2 GameObjects' coordinations")]
    [SerializeField]
    private GameObject fromVector;
    [SerializeField]
    private GameObject toVector;

    [SerializeField]
    private Vector3 finalVector;

    [Header("Insert turning on/off light GameObject")]
    [SerializeField]
    private TurnOnLight lampLightStatus;

    [Header("StoryEventHandler Related")]
    [SerializeField]
    private int rayCastHitID;

    /*[Header("Toggle TextPanel On when text playing & Off when not playing")]
    [SerializeField]
    private string textPanelManagerTag = "TextPanelAnimationManager";
    private GameObject textPanelManager;*/

    [Header("Handler that open door SLIGHTLY")]
    [SerializeField]
    private GameObject handler_0DoorSLIGHTLY;

    //private TextPanelAnimationController textPanelAnimationController;

    private Ray myLampRay;
    private RaycastHit rayHit;

    // Start is called before the first frame update
    void Start()
    {
        //textPanelManager = GameObject.FindGameObjectWithTag(textPanelManagerTag);
        //textPanelAnimationController = textPanelManager.gameObject.GetComponent<TextPanelAnimationController>();

        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //my ray's origin point starts at lampLightSource's position and hit towards (laser pointer)
        myLampRay.origin = lampLight.transform.position;

        //Calculating the ray's direction with 2 pints
        finalVector = toVector.transform.position - fromVector.transform.position;

        //If Light is on -> Cast the ray fromCord to toCord
        if(lampLightStatus.IsLightOn == true)
        {
            //Debug visible Ray
            Debug.DrawLine(myLampRay.origin , rayHit.point , Color.red);

            if (Physics.Raycast(myLampRay.origin , finalVector , out rayHit))
            {
                if (rayHit.transform.CompareTag(targetTag))
                {
                    //Animator animator = textPanelAnimationController.TextPanelAnimator;
                    //animator.Play("TurnOnTextPanel");

                    //If ray hit old man's eye -> Play MurderEvent
                    //Mean I'm the handler
                    StoryEventManager.MurderEvent(rayCastHitID);

                    Debug.Log("Lamp hit oldman");
                    handler_0DoorSLIGHTLY.SetActive(false);
                }
                else
                {
                    //Debug.Log("Ray is casting but no correct target hit" + rayHit.transform.name);
                }
            }
        }

        else
        {
            finalVector = Vector3.zero;
        }

    }
}
