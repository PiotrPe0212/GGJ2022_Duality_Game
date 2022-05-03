using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private LayerMask _layerToDetect;
    [SerializeField] private GameObject laserBeam;
    [SerializeField] private AudioSource laserSound;

    private float speed = 10;
    private float border = 5;
    private float nextShootTime;
    private bool lastDetection; //false means left, true means right;
    private Vector3 beamPosMid;
    private Vector3 beamPosRight;
    private Vector3 beamPosLeft;
    public bool hitLeft;
    public bool hitMid;
    public bool hitRight;
    RaycastHit2D hitL;
    RaycastHit2D hitM;
    RaycastHit2D hitR;

    void Start()
    {

    }
    void FixedUpdate()
    {
        beamPosLeft = new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y - 0.2f, 0);
        beamPosMid = new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y, 0);
        beamPosRight = new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y + 0.2f, 0);
        hitL = Physics2D.Raycast(beamPosLeft, Vector2.left, 20, _layerToDetect);
        hitM = Physics2D.Raycast(beamPosMid, Vector2.left, 20, _layerToDetect);
        hitR = Physics2D.Raycast(beamPosRight, Vector2.left, 20, _layerToDetect);
        if (hitL)
        {
            if (hitL.collider.name == "Player1") hitLeft = true;
            else hitLeft = false;
        }
        else hitLeft = false;

        if (hitM)
        {
            if (hitM.collider.name == "Player1") hitMid = true;
            else hitMid = false;
        }
        else hitMid = false;


        if (hitR)
        {

            if (hitR.collider.name == "Player1") hitRight = true;
            else hitRight = false;
        }
        else hitRight = false;

        PlayerDetected1();

        if (hitMid)
        {
            if (Time.time < nextShootTime) return;
            nextShootTime = Time.time + 0.5f;
            LaserShoot();
        }
    }

    private void PlayerDetected1()
    {
        if (hitLeft && hitMid && hitRight) return;
        if (hitLeft && hitMid || hitLeft) transform.Translate(Vector3.up * Time.deltaTime * -1 * speed);
        if (hitRight && hitMid || hitRight) transform.Translate(Vector3.up * Time.deltaTime * 1 * speed);
        if (!hitMid && hitLeft) lastDetection = false;
        if (!hitMid && hitRight) lastDetection = true;
        if (!hitLeft && !hitMid && !hitRight)
        {
            if (!lastDetection)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -1 * speed);
                if (transform.position.y <= -border) lastDetection = !lastDetection;
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * 1 * speed);
                if (transform.position.y >= border) lastDetection = !lastDetection;
            }

        }

    }

    private void LaserShoot()
    {

        Instantiate(laserBeam,
                    new Vector3(gameObject.transform.position.x - 1.2f, gameObject.transform.position.y + 0.4f, 0),
                    Quaternion.Euler(Vector3.forward * 180));
        laserSound.Play();
    }

}
