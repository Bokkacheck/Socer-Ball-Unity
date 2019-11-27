using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Rigidbody ball;
    [SerializeField]
    private float speed;
    private Rigidbody enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowBall();
    }
    private void FollowBall()
    {
        Vector3 direction = Vector3.zero;
        RaycastHit hit;
        if(Physics.Raycast(ball.position,ball.velocity,out hit, 200))
        {
            if (hit.collider.name == "EnemyGoal")
            {
                direction = new Vector3(ball.position.x, 0, ball.position.z + 2.0f) - enemy.position;
            }
            else
            {
                direction = ball.position - enemy.position;
            }
        }
        else
        {
            direction = ball.position - enemy.position;
        }
        direction.y = 0;
        float distance = direction.magnitude;
        if (distance > 0.5)
        {
            direction = direction.normalized;
            enemy.velocity = new Vector3(direction.x * speed, enemy.velocity.y, direction.z * speed);
        }
    }
}
