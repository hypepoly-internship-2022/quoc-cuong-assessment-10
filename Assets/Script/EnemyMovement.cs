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
             MoveTarget(0, 0, speedUWant);
        }
    }

    private void enemyIdle(){
        if(timeIdle > 0)
        {
            timeIdle -= Time.deltaTime;
            CustomMaterial(material[0]);
        }
        else 
        {
            isCollided = false;
            PlayAni();
            CustomMaterial(material[1]);
            timeIdle = 2f;
        }
    }

    public void EndMove()
    {
        this.GetComponent<EnemyMovement>().enabled = false;
    }

}
