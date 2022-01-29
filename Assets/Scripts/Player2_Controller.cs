using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Controller : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private int speed = 10;
    [SerializeField] private float border = 5.5f;
    [SerializeField] private GameObject laserBeam;
    private AudioSource laserSound;
    private float verticalValue;
    private bool hit;
    public static float initialHealth = 1;
    public static float healthLoose = 0.05f;
    private float playerHealth;

    SpriteRenderer playerColor;
    UnityEngine.Color initColor;

    public event Action HealthLoose;

    private void Awake()
    {
        gameManager.ResetParameters += resetParameters;
    }

    private void OnDestroy()
    {
        gameManager.ResetParameters -= resetParameters;
    }
    void Start()
    {
        resetParameters();
        playerColor = GetComponent<SpriteRenderer>();
        laserSound = gameObject.GetComponent<AudioSource>();
        initColor = playerColor.color;

    }

  
    void Update()
    {
        if(Time.timeScale != 0)
        {
            verticalValue = Input.GetAxis("Vertical1");

            if (transform.position.y > border)
            {
                transform.position = new Vector3(transform.position.x, border, 0);
            }
            else if (transform.position.y < -border)
            {
                transform.position = new Vector3(transform.position.x, -border, 0);
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * verticalValue * speed);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(laserBeam,
                     new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y + 0.4f, 0),
                     Quaternion.Euler(Vector3.forward * 180));
                laserSound.Play();
            }

        }
     
    }

    private void FixedUpdate()
    {
        if (hit)
        {
            afterHitFunction();
            HealthFunction();
            hit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hit = true;
    }

    void afterHitFunction()
    {
       
        playerColor.color = Color.red;
        if(playerColor.color == Color.red) StartCoroutine(HitEffect());


       
    }
   private  IEnumerator HitEffect()
    {
        yield return new WaitForSeconds(0.2f);
        playerColor.color = initColor;
    }

    private void HealthFunction()
    {
        playerHealth -= healthLoose;
        HealthLoose();
    }

    void resetParameters()
    {
        hit = false;
        playerHealth = initialHealth;
        gameObject.transform.position = new Vector3(9.3f, 0, 0);
    }

}
