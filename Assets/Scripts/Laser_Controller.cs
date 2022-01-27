using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Controller : MonoBehaviour
{
    [SerializeField] private int speed = 15;
    [SerializeField] private float border = 11.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(transform.position.y > border)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
