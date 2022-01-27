using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission_Effect : MonoBehaviour
{

    [SerializeField] private GameObject lightBeam;
    [SerializeField] private int beamsNumber = 8;
    [SerializeField] private float areaInDegrees = 360;
    [SerializeField] private float beamRotation = 45;
   private bool activated;
    private float hitDirection;

    void Start()
    {
        activated = false;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitDirection = collision.transform.eulerAngles.z;
        Debug.Log(hitDirection);
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
            totalAngle = hitDirection + 45 - i * beamRotation;
            Xpos = -1.2f * Mathf.Sin(totalAngle * Mathf.Deg2Rad);
            Ypos = 1.2f * Mathf.Cos(totalAngle * Mathf.Deg2Rad);

            Instantiate(lightBeam,
               new Vector3(transform.position.x + Xpos + 0.2f, transform.position.y + Ypos, transform.position.z),
               Quaternion.Euler(Vector3.forward * totalAngle));

        }
        activated = true;
    }
}