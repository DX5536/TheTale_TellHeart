using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ColliderTransitScene : MonoBehaviour
{
    [SerializeField]
    private string player;

    //[SerializeField]
    //private GameObject loadWhichScene;

    [SerializeField]
    private string levelChangerTag = "LevelChanger";
    private GameObject levelChanger;
    private LevelChangerController levelChangerController;

    private void Start()
    {
        levelChanger = GameObject.FindGameObjectWithTag(levelChangerTag);
        levelChangerController = levelChanger.GetComponent<LevelChangerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            //Get the scene from the wanted GO
            //And Load it when player collide in

            /*var myScript = loadWhichScene.gameObject.GetComponent<LoadScene>();
            myScript.LoadSceneButton();*/

            //Fancier level Loader with FadeOut
            levelChangerController.FadeToLevel();

        }
    }
}
