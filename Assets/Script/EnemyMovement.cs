using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speedUNeed;
    [SerializeField] private Material[] material;
    [SerializeField] private GameObject containEnemy;

    private Rigidbody rigidBody;
    private bool isCollided;
    private float timeIdle;
    private Renderer rend;
    private Animation aniEnemy;

    // Start is called before the first frame update
    private void Start()
    {
        timeIdle = 2f;
        rigidBody = this.GetComponent<Rigidbody>();
        rend = this.GetComponent<Renderer>();
        aniEnemy = containEnemy.GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Wall")
        {   
            isCollided = true;
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
        if(isCollided == true)
        {
            timeEnemyIdle();
        }
    }

    private void FixedUpdate() {
        if(isCollided == false)
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
            isCollided = false;
            aniEnemy.Play();
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
