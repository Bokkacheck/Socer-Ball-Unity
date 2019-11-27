using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody player;
    private BallCollision ballCollision;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Rigidbody>();
        ballCollision = GetComponent<BallCollision>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
