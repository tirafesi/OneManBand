﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour 
{
    public CameraAnimation camAnimation;
    
    private int direction;
    private Island island;

    // Use this for initialization
    private void Start() 
    {
        island = transform.root.GetComponent<Island>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            PlayerMovement Player = GameObject.Find("PlayerPivot").GetComponent<PlayerMovement>();
            if(other.transform.position.x < transform.position.x)
                direction = 1;
            else
                direction = -1;
            for (int i = 0; i < GetComponent<Renderer>().bounds.size.x; i++)
                Player.QueueAnimation(new AnimationItem(Vector3.right * direction, Player.baseSpeed, true, true));

            camAnimation.MoveCamera(Vector3.right * direction * island.cameraShift);
        }
    }
}
