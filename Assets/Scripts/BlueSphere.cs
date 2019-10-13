using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSphere : MonoBehaviour
{

    DashSceneController controller;

    void Start()
    {
        controller = GameObject.FindGameObjectsWithTag("Controller")[0].GetComponent<DashSceneController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sonic"))
        {
            controller.ChangeBoostMeterValue(10f);
            Destroy(gameObject);

        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
