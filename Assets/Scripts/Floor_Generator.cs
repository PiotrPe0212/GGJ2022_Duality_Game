using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] floorTile;
    [SerializeField] private float YInitPos = -14;
    [SerializeField] private float XInitPos = -6;
    // Start is called before the first frame update
    void Start()
    {
        int stepSize = 2;
        float YActualPos = YInitPos;
        float XActualPos = XInitPos;
        int[] rotationArray = new int [4];
        rotationArray[0] = 0;
        rotationArray[1] = 90;
        rotationArray[2] = 180;
        rotationArray[3] = 270;

        while (YActualPos <= -YInitPos)
        {
            while (XActualPos <= -XInitPos)
            {
                int randomTile = Random.Range(0, floorTile.Length);
                int randomRotation = Random.Range(0, rotationArray.Length);

                var Tile = Instantiate(floorTile[randomTile], new Vector3(XActualPos, YActualPos, 0), Quaternion.Euler(Vector3.forward * rotationArray[randomRotation]));
                Tile.transform.parent = gameObject.transform;               
                XActualPos += stepSize;
            }
            XActualPos = XInitPos;
            YActualPos += stepSize;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
