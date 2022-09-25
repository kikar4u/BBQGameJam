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
            DOTween.To(() => fov, x => fov = x, 105, 0.5f)
            .OnUpdate(() => {
                GameCamera.m_Lens.FieldOfView = fov;
            });

        }
        else
        {
            DOTween.To(() => fov, x => fov = x, 23, 0.5f)
            .OnUpdate(() => {
                GameCamera.m_Lens.FieldOfView = fov;
            });
            //GameCamera.m_Lens.FieldOfView = 23;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
