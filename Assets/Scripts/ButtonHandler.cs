using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody player;
    private BallCollision ballCollision;
    private bool pressed = false;
    private int brojac = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("Ball").GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Rigidbody>();
        ballCollision = GameObject.Find("Ball").GetComponent<BallCollision>();
    }
    void Update()
    {
        if (pressed)
        {
            pressed = false;
            player.gameObject.GetComponent<PlayerMovement>().speed *= 4;
        }
    }
    public void Click()
    {
        //if (ballCollision.IsTouching())
        //{
        //    rb.AddForce(player.velocity.normalized * 150 + new Vector3(0,  40, 0));
        //}
    }
    public void Pressed()
    {
        pressed = true;
    }
    public void Released()
    {
        player.gameObject.GetComponent<PlayerMovement>().speed /= 4;
        pressed = false;
    }
}
