﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    DashSceneController controller;

    void Start()
    {
        controller = GameObject.FindGameObjectsWithTag("Controller")[0].GetComponent<DashSceneController>();
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Sonic")){
            if(!DashSceneController.isInvincible){
                controller.EndGame();
            }
        }
    }
}
