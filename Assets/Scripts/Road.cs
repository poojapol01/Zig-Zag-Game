using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPos;
    private float offset = 0.707f;
    private int roadCount = 0;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.5f);
    }

    public void CreateNewRoadPart()
    {
        Debug.Log("New Road Part Created");

        Vector3 spwanPos = Vector3.zero;

        float chance = Random.Range(0, 100);

        if(chance < 50)
        {
            spwanPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spwanPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        GameObject g = Instantiate(roadPrefab, spwanPos, Quaternion.Euler(0, 45, 0));

        lastPos = g.transform.position;
        roadCount++;

        if(roadCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateNewRoadPart();
        }
    } */

}
