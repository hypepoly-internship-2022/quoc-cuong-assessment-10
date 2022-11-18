using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameMgr
{

    [SerializeField] private GameObject containPlayer;
    [SerializeField] private float speedUWant;
    [SerializeField] private Material[] material;

    public bool isWon;
    public bool isLose;

    private bool isMoving;
    private bool isClicked;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    private void Start()
    {
        OnLoadScene(containPlayer);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.name == "Wall (1)")
        {   
            isWon = true;
        } 
        else 
        {
            isLose = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        playerIdle();

        if(Input.GetMouseButton(0))
        {
            if(isMoving == true)
            {
                isClicked = true;
            }
            else
            {
                isClicked = false;
            }
        }
        else
        {
            isClicked = false;
        }
    }

    private void FixedUpdate()
    {
        if(isClicked == true)
        {
            checkInputClick();
        }
        else
        {
            MoveTarget(0, 0, 0);
        }
    }

    private void checkInputClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                Vector3 pos = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
                this.transform.position = pos;
            }  
            else
            {
                MoveTarget(-speedUWant, 0, 0);
            } 
        }
    }

    private void playerIdle(){
        if(timeIdle > 0.5f)
        {
            timeIdle -= Time.deltaTime;
            CustomMaterial(material[0]);
            isMoving = false;
            PlayAni();
        }
        else
        {
            CustomMaterial(material[1]);
            timeIdle -= Time.deltaTime;
            if(timeIdle > 0 && timeIdle < 0.5f){
                isMoving = true;
            }
            else
            {
                timeIdle = 2f;
            }
        }
    }

    public void EndMove()
    {
        this.GetComponent<PlayerController>().enabled = false;
    }
}
