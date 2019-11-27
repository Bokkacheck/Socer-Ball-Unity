using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private JoyStick joyStick;
    [SerializeField]
    public float speed = 5.0f;
    [SerializeField]
    private GameObject cameraLook;
    private Rigidbody player;
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 velocity = joyStick.PerformMovement();
        if (velocity != Vector3.zero)
        {
            velocity = (velocity.x * cameraLook.transform.right + velocity.z * cameraLook.transform.forward).normalized*speed;
            player.velocity = new Vector3(velocity.x, player.velocity.y, velocity.z);
        }
    }   
}
