using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    [SerializeField] private float border = 9.5f;
    [SerializeField] private GameObject laserBeam;
    private float horizontalValue;
    private bool hit;

    SpriteRenderer playerColor;
    UnityEngine.Color initColor;
    void Start()
    {
        hit = false;
        playerColor = GetComponent<SpriteRenderer>();
        initColor = playerColor.color;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal1");

        if (transform.position.x > border )
        {
            transform.position = new Vector3(border, transform.position.y, 0);
        }
        else if(transform.position.x < -border)
        {
            transform.position = new Vector3(-border, transform.position.y, 0);
        }
        else 
        { 
            transform.Translate(Vector3.right * Time.deltaTime * horizontalValue * speed);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(laserBeam, 
                new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y+1, 0),
                laserBeam.transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        if (hit)
        {
            afterHitFunction();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hit = true;
    }

    void afterHitFunction()
    {
        
        playerColor.color = Color.red;
       if (playerColor.color == Color.red) StartCoroutine(HitEffect());
        
    }

    private IEnumerator HitEffect()
    {
        yield return new WaitForSeconds(0.2f);
        playerColor.color = initColor;
        hit = false;
    }
}
