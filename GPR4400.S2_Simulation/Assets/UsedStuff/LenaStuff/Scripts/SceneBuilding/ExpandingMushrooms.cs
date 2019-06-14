﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingMushrooms : MonoBehaviour
{
    public GameObject MushroomPrefab;
    public int AmountOfMushrooms = 500;
    public int xMin = 1;
    public int xMax = 7;
    public int zMin = 1;
    public int zMax = 7;

    public LayerMask TerrainLayer;

    private RaycastHit hit;
    private float terrainY;
    private float x;
    private float z;
    private float y;
    private Vector3 hikingPoint;

    void Start()
    {
        x = Random.Range(xMin, xMax);
        z = Random.Range(zMin, zMax);
        StartCoroutine(SentHikingPoint());
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(new Vector3(hikingPoint.x, 100, hikingPoint.z), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
        {
            terrainY = hit.point.y;
        }
        y = terrainY;
        hikingPoint = new Vector3(hikingPoint.x, y, hikingPoint.z);
    }

    IEnumerator SentHikingPoint()
    {
        for (int i = 0; i < AmountOfMushrooms; i++)
        {
            int q = Random.Range(1, 5);
            if (q == 1)
            {
                hikingPoint += new Vector3(0.3f, 0, 0);
                Instantiate(MushroomPrefab, hikingPoint, Quaternion.identity);
            }
            else if (q == 2)
            {
                hikingPoint += new Vector3(0, 0, -0.3f);
                Instantiate(MushroomPrefab, hikingPoint, Quaternion.identity);
            }
            else if (q == 3)
            {
                hikingPoint += new Vector3(-0.3f, 0, 0);
                Instantiate(MushroomPrefab, hikingPoint, Quaternion.identity);
            }
            else if (q == 4)
            {
                hikingPoint += new Vector3(0, 0, 0.3f);
                Instantiate(MushroomPrefab, hikingPoint, Quaternion.identity);
            }

            yield return new WaitForSeconds(0.75f / SimulationManager.Instance.Celerity);
        }
    }
}
