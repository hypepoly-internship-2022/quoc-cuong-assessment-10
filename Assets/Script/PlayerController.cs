using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameMgr
{

    [SerializeField] private GameObject containPlayer;
    [SerializeField] private float speedUWant;
    [SerializeField] private Material[] material;

    // Start is called before the first frame update
    private void Start()
    {
        OnLoadScene(containPlayer);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void AniPlayer()
    {
        
    }

    private void movePlayer() 
    {
        rigidBody.AddForce(-speedUWant, 0, 0);
    }
}
