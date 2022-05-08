using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission_Effect : MonoBehaviour
{

    [SerializeField] private GameObject lightBeam;
    [SerializeField] private int beamsNumber = 8;
    [SerializeField] private float beamRotation = 45;
   private bool activated;
    private float hitDirection;
    private UnityEngine.Color[] colorsArray = new UnityEngine.Color [5];

    void Start()
    {
        activated = false;
        colorsArray[0] = Color.red;
        colorsArray[1] = Color.yellow;
        colorsArray[2] = Color.green;
        colorsArray[3] = Color.blue;
        colorsArray[4] = Color.magenta;
       
       
        
    }

    void Update()
    {
        activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitDirection = collision.transform.eulerAngles.z;
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
            totalAngle = hitDirection + 60 - i * beamRotation;
            Xpos = 1.2f * Mathf.Sin(totalAngle * Mathf.Deg2Rad);
            Ypos = -1.2f * Mathf.Cos(totalAngle * Mathf.Deg2Rad);

            GameObject beam = Instantiate(lightBeam,
               new Vector3(transform.position.x + Xpos , transform.position.y + Ypos - 0.2f, transform.position.z),
               Quaternion.Euler(Vector3.forward * totalAngle));

           if(beamsNumber == colorsArray.Length)
            beam.GetComponent<SpriteRenderer>().color = colorsArray[i];
        }
        activated = true;
    }

    
}
