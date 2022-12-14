using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafe : MonoBehaviour
{
    public GameManager gManager;
    public AudioClip slurp;
    public AudioSource slurpSource;
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Collider");
            gManager.addCafe();
            gManager.randomSpawn(gManager.listSpawnCafe);
            slurpSource.PlayOneShot(slurp);
            Destroy(gameObject, 1.0F);
        }
    }

}
