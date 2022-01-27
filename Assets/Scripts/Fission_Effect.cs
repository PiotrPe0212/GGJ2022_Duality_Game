using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fission_Effect : MonoBehaviour
{
    [SerializeField] private GameObject lightBeam;
    [SerializeField] private int beamsNumber = 5;
    [SerializeField] private float areaInDegrees = 90;
    [SerializeField] private float beamRotation = 22.5f;
    private bool activated;
   

    void Start()
    {
        activated = false;

    }
    void Update()
    {
        activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated) return;
        activated = true;
            emissionFunction();
    }

    void emissionFunction()
    {
        float totalAngle;
        float Xpos;
        float Ypos;
        for (int i = 0; i < beamsNumber; i++)
        {
            totalAngle = 45 - i * beamRotation;
            Xpos = -1.2f*Mathf.Sin(totalAngle * Mathf.Deg2Rad);
            Ypos = 1.2f*Mathf.Cos(totalAngle * Mathf.Deg2Rad);
           
            Instantiate(lightBeam,
               new Vector3(transform.position.x + Xpos+0.2f, transform.position.y + Ypos, transform.position.z),
               Quaternion.Euler(Vector3.forward * totalAngle));
          
        }
        activated = true;
    }
}
