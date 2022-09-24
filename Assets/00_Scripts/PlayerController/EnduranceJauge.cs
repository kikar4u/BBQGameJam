using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnduranceJauge : MonoBehaviour
{
    [SerializeField] float jaugeCafe = 100.0f;
    [SerializeField] float decreaseRatio = 1.0f;
    [SerializeField] float decreaseSpeed = 0.1f;
    [SerializeField] Slider endurance;
    // Start is called before the first frame update
    void Start()
    {
        endurance = GameObject.FindGameObjectWithTag("enduranceSlider").GetComponent<Slider>();
        endurance.value = jaugeCafe;
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
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(enduranceTimer());
    }
}
