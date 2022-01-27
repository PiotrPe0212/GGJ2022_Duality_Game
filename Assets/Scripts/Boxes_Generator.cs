using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes_Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] boxesTypeArr;
    [SerializeField] private float timeToSpawn = 3;
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("NewBox", 3, timeToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewBox()
    {
        int boxNumber = Random.Range(0, boxesTypeArr.Length);
        float yBoxPos = Random.Range(-0.5f, 0.5f);
        Instantiate(boxesTypeArr[boxNumber], 
            new Vector3( gameObject.transform.position.x -12, gameObject.transform.position.y + yBoxPos, 0),
            gameObject.transform.rotation);
    }
}
