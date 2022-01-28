using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    [SerializeField] private float border = 5.5f;
    [SerializeField] private GameObject laserBeam;
    public float verticalValue;
    private bool hit;

    SpriteRenderer playerColor;
    UnityEngine.Color initColor;
    void Start()
    {
        hit = false;
        playerColor = GetComponent<SpriteRenderer>();
        initColor = playerColor.color;

    }


    void Update()
    {
        verticalValue = Input.GetAxis("Vertical1");

        if (transform.position.y > border )
        {
            transform.position = new Vector3( transform.position.x, border, 0);
        }
        else if(transform.position.y < -border)
        {
            transform.position = new Vector3(transform.position.x, -border,  0);
        }
        else 
        { 
            transform.Translate(Vector3.up * Time.deltaTime * verticalValue * speed);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(laserBeam, 
                new Vector3 (gameObject.transform.position.x+1, gameObject.transform.position.y, 0),
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
