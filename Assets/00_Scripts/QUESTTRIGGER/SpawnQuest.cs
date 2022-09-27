using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuest : MonoBehaviour
{
    [SerializeField] GameObject[] questToSpawn;
    [SerializeField] GameObject[] gArray;
    private void Start() {
        gArray = GameObject.FindGameObjectsWithTag(gameObject.tag);
        
    }
    // Start is called before the first frame update
    public void spawnObject()
    {
            int a;
            int i = 0;
            
            do {
                a = Random.Range(0, questToSpawn.Length);
                Debug.Log(i);
                i++;

            }
            while(gArray[i - 1].transform.position == gameObject.transform.position);
            if(gArray[i - 1].transform.position != gameObject.transform.position){
                GameObject quest = Instantiate(questToSpawn[a]);
                Debug.Log("POP");
                quest.transform.position = gameObject.transform.position;
            }

            // foreach(GameObject item in gArray) {
            //     if(item.transform.position == gameObject.transform.position){
            //         Debug.Log(gArray[0].transform.position);
            //     }
            // }

        //Debug.Log("ça pop");


    }
}
