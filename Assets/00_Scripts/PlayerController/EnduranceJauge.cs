using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnduranceJauge : MonoBehaviour
{
    [SerializeField] float jaugeCafe = 100.0f;
    [SerializeField] float decreaseRatio = 1.0f;
    [SerializeField] float decreaseSpeed = 0.1f;
    [SerializeField] public Slider endurance;
    Coroutine CoEndurance;
    [SerializeField] GameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        endurance = GameObject.FindGameObjectWithTag("enduranceSlider").GetComponent<Slider>();
        endurance.value = jaugeCafe;
        CoEndurance = StartCoroutine(enduranceTimer());
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    IEnumerator enduranceTimer()
    {
        
        for (float i = jaugeCafe; i >= 0; i -= decreaseRatio)
        {
            jaugeCafe = i;
            endurance.value = jaugeCafe;
            
            yield return new WaitForSeconds(decreaseSpeed);
        }
    }
    IEnumerator enduranceUp()
    {
        for (float i = jaugeCafe; i <= endurance.maxValue; i += decreaseRatio)
        {
            //Debug.Log("fjqsoidfjioqsdfjioqs");
            jaugeCafe = i;
            endurance.value = jaugeCafe;
            if(endurance.value == endurance.maxValue)
            {
                StopCoroutine(CoEndurance);
                CoEndurance = StartCoroutine(enduranceTimer());
                gManager.triggerFakePause(false);
            }
            yield return new WaitForSeconds(decreaseSpeed);
        }
    }
    public void switchRoutine(bool etat = false)
    {
        Debug.Log("prout");
        if (etat)
        {
            // remise endurance
            //Debug.Log("fjdioqjidoshello");
            StopCoroutine(CoEndurance);
            gManager.triggerFakePause(true);
            CoEndurance = StartCoroutine(enduranceUp());

        }
        else
        {
            Debug.Log("boup");
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
