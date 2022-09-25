using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOutPause : MonoBehaviour
{
    public Canvas pauseUI;
    public bool etat = false;
    public CameraControl cameraControl;
    public GameManager gManager;
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnEnable()
    {
        etat = true;
    }
    public void outPause()
    {
        pauseUI.gameObject.SetActive(false);
        cameraControl.lerping(true);
        gManager.canMove = true;
        gManager.gameObject.GetComponent<EnduranceJauge>().etatPauseUI = false;
    }
    private void OnDisable()
    {
        etat = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
