using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuest : MonoBehaviour
{
    [SerializeField] GameObject questToSpawn;
    // Start is called before the first frame update
    public void spawnObject()
    {
        //Debug.Log("ça pop");
        GameObject quest = Instantiate(questToSpawn);
        quest.transform.position = gameObject.transform.position;

    }
}
