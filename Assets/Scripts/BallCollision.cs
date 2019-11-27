using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private bool touching;
    private Rigidbody enemyRb;
    private Rigidbody ballRb;
    void Start()
    {
        enemyRb = GameObject.Find("Enemy").GetComponent<Rigidbody>();
        ballRb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.name == "Player")
        {
            touching = true;
        }
        else if (other.collider.name == "Enemy")
        {
            RaycastHit hit = new RaycastHit();
            if(Physics.Raycast(ballRb.position,enemyRb.velocity,out hit, 200))
            {
                if(hit.collider.name != "EnemyGoal")
                {
                    ballRb.AddForce(other.collider.GetComponent<Rigidbody>().velocity.normalized * 100 + new Vector3(0, 30, 0));
                }
            }
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.collider.name == "Player")
        {
            touching = false;
        }
    }
    public bool IsTouching()
    {
        return touching;
    }
}
