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
    public Coroutine CoEndurance;
    [SerializeField] GameManager gManager;
    public CameraControl cameraControl;
    public Canvas pauseUI;
    public bool etatPauseUI = true;

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
                Debug.Log(pauseUI.GetComponent<GetOutPause>().etat);
                if (!etatPauseUI)
                {
                    Debug.Log("POPIPOP");

                    pauseUI.GetComponent<GetOutPause>().etat = false;
                    StopCoroutine(CoEndurance);
                    etatPauseUI = true;
                    //CoEndurance = StartCoroutine(enduranceTimer());
                    //gManager.triggerFakePause(false);
                    


                }
/*                else
                {
                    StopCoroutine(CoEndurance);
                    CoEndurance = StartCoroutine(enduranceTimer());
                }*/

                

                

            }
            if (i > endurance.maxValue)
            {
                i = endurance.maxValue;
            }
            yield return new WaitForSeconds(0.090f);
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
            gManager.canMove = false;
            cameraControl.lerping(false);
            CoEndurance = StartCoroutine(enduranceUp());

        }
        else
        {
            Debug.Log("boup");
            StopCoroutine(enduranceUp());
            CoEndurance = StartCoroutine(enduranceTimer());

        }

    }
    // Update is called once per frame
    void Update()
    {
        if(endurance.value == 0)
        {
            gManager.GameOver(true);
        }
        
    }
}
