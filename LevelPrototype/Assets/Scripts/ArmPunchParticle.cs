using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPunchParticle : MonoBehaviour
{
    public GameObject rightPunch;
    public CameraShake cameraShake;

    void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            rightPunch.SetActive(true);
            cameraShake.Shake();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            rightPunch.SetActive(false);
        }
    }

}
