﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController: MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    public GameObject[] obstacles;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform obstaclesSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        // GenerateObjects
        if (counter <= 0.0f)
        {
            GenerateRandomObstacle();
        }
        else
        {
            counter -= Time.deltaTime * frequency;
        }
        // Scrolling
        GameObject currentChild;
        for (int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollObstacle(currentChild);
            if (currentChild.transform.position.x <= -15.0f)
            {
                Destroy(currentChild);
            }
        }
    }
    void ScrollObstacle(GameObject currentObstacle)
    {
        currentObstacle.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }
    void GenerateRandomObstacle()
    {
        GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], obstaclesSpawnPoint.position, Quaternion.identity) as GameObject;
        newObstacle.transform.parent = transform;
        counter = 1.0f;
    }




}
