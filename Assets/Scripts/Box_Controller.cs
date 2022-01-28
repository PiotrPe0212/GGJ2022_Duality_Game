using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Controller : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private float border = -7f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y > border)
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        if (Time.timeScale == 0) Destroy(gameObject);
    }
}
