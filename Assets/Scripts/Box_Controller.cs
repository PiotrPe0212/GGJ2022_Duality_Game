using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Controller : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private float border = 11.0f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > border)
        {
            Destroy(gameObject);
        }

    }
}
