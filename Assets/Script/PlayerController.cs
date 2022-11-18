using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameMgr
{

    [SerializeField] private GameObject containPlayer;
    [SerializeField] private float speedUWant;
    [SerializeField] private Material[] material;

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
                MoveTarget(0, 0, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        if(isClicked == true)
        {
            checkClickOnCube();
        }
    }

    private void checkClickOnCube()
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
}
