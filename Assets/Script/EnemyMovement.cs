using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : GameMgr
{
    [SerializeField] private float speedUWant;
    [SerializeField] private Material[] material;
    [SerializeField] private GameObject containEnemy;

    // Start is called before the first frame update
    private void Start()
    {
        OnLoadScene(containEnemy);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Wall")
        {   
            isCollided = true;
            speedUWant = -speedUWant;
        } 
        else 
        {
            EndMove();
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        if(isCollided == true)
        {
            enemyIdle();
        }
    }

    private void FixedUpdate() {
        if(isCollided == false)
        {
            moveEnemy();
        }
    }

    private void enemyIdle(){
        if(timeIdle > 0)
        {
            timeIdle -= Time.deltaTime;
            rend.sharedMaterial = material[0];
        }
        else 
        {
            isCollided = false;
            ani.Play();
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
        rigidBody.AddForce(0, 0, speedUWant);
    }

}
