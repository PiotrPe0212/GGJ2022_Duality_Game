using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Controller : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private float border = 11.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > border)
        {
            Destroy(gameObject);
        }

    }
}
