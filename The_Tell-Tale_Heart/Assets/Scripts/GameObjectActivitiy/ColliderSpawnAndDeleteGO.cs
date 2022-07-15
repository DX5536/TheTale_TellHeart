using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColliderSpawnAndDeleteGO : MonoBehaviour
{
    [SerializeField]
    private string player;

    [Header("GameObject to Delete")]
    [SerializeField]
    private GameObject deleteGO;

    private Vector3 deleteGOPosition;
    private Quaternion deleteGORotation;


    [Header("GameObjects/Prefabs to spawn")]
    [SerializeField]
    private GameObject[] spawnObjects;

    private void Start()
    {
        //Save init OldMan Eye position and rotation
        deleteGOPosition = deleteGO.transform.position;
        deleteGORotation = deleteGO.transform.rotation;
    }

    //OntriggerEnter called twice... Sometime
    //Cuz Children in Player is also tagged Player -_-
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            deleteGO.SetActive(false);
            SpawningGameObjects();

            //Debug.Log("Box collide with " + other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }

    private void SpawningGameObjects()
    {
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            GameObject myClone = Instantiate(spawnObjects[i] , deleteGOPosition, deleteGORotation);
        }

        //Instantiate(spawnObjects[0] , deleteGOPosition , deleteGORotation);
        //Debug.Log("Spawning...");
        //GameObject testGO = new GameObject(spawnObjects[0].name);
    }
}
