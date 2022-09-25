using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] footSteps;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       //audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void Footsteps()
    {
       // Debug.Log("footsteps");
        int a = Random.Range(0, footSteps.Length);
        //gameObject.GetComponent<AudioSource>().clip = footSteps[a];
        audioSource.PlayOneShot(footSteps[a]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
