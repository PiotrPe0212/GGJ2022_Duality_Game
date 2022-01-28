using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Controller : MonoBehaviour
{
   
    [SerializeField] private int speed = 15;
    [SerializeField] private float border = 11.0f;


    void Start()
    {
        
    }


    void FixedUpdate()
    {
       
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (transform.position.y > border || transform.position.y < -border)
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if(Time.timeScale ==0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Stop")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Reflect")
        {
            if(transform.rotation.z == 0)
           gameObject.transform.rotation = Quaternion.Euler(Vector3.forward*180);
            else
                gameObject.transform.rotation = Quaternion.Euler(Vector3.forward);
        }
        if(other.tag == "Break")
        {
           
            float refractionAngle = Random.Range(-60, 60);
            if (transform.rotation.z == 0)
                transform.rotation = Quaternion.Euler(Vector3.forward *refractionAngle);
            else
                transform.rotation = Quaternion.Euler(Vector3.forward * (180+refractionAngle));
        }

    }
}
