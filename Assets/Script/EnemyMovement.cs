using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speedUNeed;
    [SerializeField] private Material[] material;

    private Rigidbody rigidBody;
    private bool isCollision;
    private float timeIdle;
    private Renderer rend;

    // Start is called before the first frame update
    private void Start()
    {
        timeIdle = 2f;
        rigidBody = this.GetComponent<Rigidbody>();
        rend = this.GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Wall")
        {   
            isCollision = true;
            speedUNeed = -speedUNeed;
        } 
        else 
        {
            EndMove();
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        if(isCollision == true)
        {
            timeEnemyIdle();
        }
    }

    private void FixedUpdate() {
        if(isCollision == false)
        {
            moveEnemy();
        }
    }

    private void timeEnemyIdle(){
        if(timeIdle > 0)
        {
            timeIdle -= Time.deltaTime;
            rend.sharedMaterial = material[0];
        }
        else 
        {
            isCollision = false;
            rend.sharedMaterial = material[1];
            timeIdle = 2f;
        }
    }

    private void EndMove()
    {
        this.GetComponent<EnemyMovement>().enabled = false;
    }

    private void moveEnemy() 
    {
        rigidBody.AddForce(0, 0, speedUNeed);
    }

}
