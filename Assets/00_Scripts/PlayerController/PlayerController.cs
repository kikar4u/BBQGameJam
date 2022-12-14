using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [Header("movements")]
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float multRun;
    
    [SerializeField] private Rigidbody2D body;
    [Header("Visual")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprRend;
    // [HideInInspector] public Door currentDoor;
    // [HideInInspector] public PickUpItem currentItem;
    private Vector3 bufferPosition;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    [SerializeField] public bool isOnQuest = false;
    [SerializeField] GameManager gManager;
    // Start is called before the first frame update    
    void Awake()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        questInteraction();
        // ControleHiding();
        //LookForward();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        ControleMoving();
    }

    // private void ControleHiding()
    // {
    //     if (Input.GetButtonDown("Fire1") )
    //     {
    //         if(currentHideout) GetHidden();
    //         if(currentItem) PickUp();
    //         if(currentDoor) OpenDoor();
    //     }
    // }

    private void ControleMoving()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float _multRun = Input.GetButton("Fire2") ? multRun : 1;

        if (gManager.canMove)
        {
            Vector2 newVelocity = new Vector2(horizontal * speed * _multRun, vertical * speed * _multRun);
            //Debug.Log(newVelocity);
            if (newVelocity.x <= 0)
            {
                sprRend.flipX = false;
            }
            else
            {
                sprRend.flipX = true;
            }
            animator.SetBool(IsMoving, newVelocity.magnitude > 0);
            animator.SetBool(IsRunning, _multRun > 1);

            body.velocity = newVelocity;
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }

        
    }
    private void questInteraction()
    {
        if (isOnQuest)
        {
/*            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("APPUYER POUR QUEST");

                //gManager.randomSpawn();

            }*/

        }

    }


    // private void OpenDoor()
    // {
    //     currentDoor.Open();
    // }

    // private void PickUp()
    // {
    //     currentItem.Pick();
    // }

    // private void LookForward()
    // {
    //     Vector3 direction = body.velocity.normalized;
    //     float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
    //     transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
    // }
}
