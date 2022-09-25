using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuest : MonoBehaviour
{
    [SerializeField] GameObject[] questToSpawn;
    // Start is called before the first frame update
    public void spawnObject()
    {
        //Debug.Log("ça pop");
        int a = Random.Range(0, questToSpawn.Length);
        GameObject quest = Instantiate(questToSpawn[a]);
        quest.transform.position = gameObject.transform.position;

    }
}
