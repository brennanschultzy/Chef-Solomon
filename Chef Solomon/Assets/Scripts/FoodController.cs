﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public int scoreVal;
    public int totalScore;
    public Transform food;
    public Transform food2;

    public float speed = 10f;
    private bool outOfBounds;
    private PlayerController playerController;

    public bool timer;

    Vector3 xMovement = (Vector3.right);

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Cleaver").GetComponent<PlayerController>();
        if (gameObject.CompareTag("Food"))
        {
            GetComponent<Renderer>().material.color = new Color(1f, 0.4858491f, 0.9789963f);
        }
        if (gameObject.CompareTag("Food 2"))
        {
            GetComponent<Renderer>().material.color = new Color(0f, 0.006470203f, 1f);
        }       
    }

        // Start is called before the first frame update
        void Start()
    {
        outOfBounds = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBounds();
    }

    public void Movement()
    {
        transform.Translate(xMovement * speed * Time.deltaTime * playerController.noteSpeed);
    }

    public void OutOfBounds()
    {
        if (!outOfBounds && transform.position.x > 12 && gameObject.CompareTag("Food"))
        {
            Spawn();
            Destroy(gameObject);
        }
        if (!outOfBounds && transform.position.x > 18 && gameObject.CompareTag("Food 2"))
        {
            Spawn2();
            Destroy(gameObject);
        }
    }

    public int AddScore(int scoreVal)
    {
        scoreVal += 100;
        totalScore = scoreVal;
        return totalScore;
    }

    public int SubScore(int scoreVal)
    {
        scoreVal -= 150;
        totalScore = scoreVal;
        return totalScore;
    }

    public void Spawn()
    {
        Instantiate(food, new Vector3(-12, 2, 0), Quaternion.identity);
    }

    public void Spawn2()
    {
        Instantiate(food2, new Vector3(-18, 2, 0), Quaternion.identity);
    }
}
