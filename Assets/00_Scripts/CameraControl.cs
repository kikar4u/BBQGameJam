using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera GameCamera;
    public GameManager gManager;
    public float fov;
    public Transform mapCenter;
    public float dezoomDistance = 7;
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        GameCamera = GameObject.FindGameObjectWithTag("VirtualC").GetComponent<CinemachineVirtualCamera>();
    }
    public void lerping(bool state)
    {
        if (!state)
        {
            DOTween.To(() => fov, x => fov = x, dezoomDistance, 0.5f)
            .OnUpdate(() => {
                GameCamera.m_Lens.OrthographicSize = fov;
                
                GameObject[] arrayQuest = GameObject.FindGameObjectsWithTag("Quest");
                foreach (GameObject item in arrayQuest)
                {
                    item.GetComponentInChildren<Transform>().localScale = new Vector3(3, 3, 3);
                }
                GameObject[] arrayCafe = GameObject.FindGameObjectsWithTag("cafe");
                foreach (GameObject item in arrayCafe)
                {
                    item.GetComponentInChildren<Transform>().localScale = new Vector3(5, 5, 5);
                }
                GameCamera.LookAt = mapCenter;
                GameCamera.Follow = mapCenter;
            });

        }
        else
        {
            DOTween.To(() => fov, x => fov = x, 2, 0.5f)
            .OnUpdate(() => {
                GameCamera.m_Lens.OrthographicSize = fov;
                GameObject[] arrayCafe = GameObject.FindGameObjectsWithTag("cafe");
                foreach (GameObject item in arrayCafe)
                {
                    item.GetComponentInChildren<Transform>().localScale = new Vector3(1, 1, 1);
                }
                GameObject[] arrayQuest = GameObject.FindGameObjectsWithTag("Quest");
                foreach (GameObject item in arrayQuest)
                {
                    item.GetComponentInChildren<Transform>().localScale = new Vector3(1, 1, 1);
                }
                GameCamera.LookAt = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                GameCamera.Follow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            });
            //GameCamera.m_Lens.FieldOfView = 23;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
