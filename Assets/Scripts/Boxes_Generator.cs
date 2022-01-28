using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes_Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] boxesTypeArr;
    [SerializeField] private float timeToSpawn = 3;
 
    void Start()
    {
       
        InvokeRepeating("NewBox", 3, Random.Range(2.1f, 4.2f));
    }

   
    void Update()
    {
        
    }

    void NewBox()
    {
        int boxNumber = Random.Range(0, boxesTypeArr.Length);
        float xBoxPos = Random.Range(-0.5f, 0.5f);
        Instantiate(boxesTypeArr[boxNumber], 
            new Vector3( gameObject.transform.position.x + xBoxPos, gameObject.transform.position.y +7, 0),
            Quaternion.Euler(Vector3.zero));
    }
}
