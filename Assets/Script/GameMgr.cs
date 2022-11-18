using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{

    protected Rigidbody rigidBody;
    protected bool isCollided;
    protected float timeIdle;
    protected Renderer rend;
    protected Animation ani;

    protected void OnLoadScene(GameObject target)
    {
        rigidBody = this.GetComponent<Rigidbody>();
        rend = this.GetComponent<Renderer>();
        ani = target.GetComponent<Animation>();
        timeIdle = 2f;
    }

    protected void MoveTarget(float x, float y, float z)
    {
        rigidBody.velocity = new Vector3(x, y, z);
    }

    protected void PlayAni(){
        ani.Play();
    }

    protected void CustomMaterial(Material mat){
        rend.sharedMaterial = mat;
    }
}
