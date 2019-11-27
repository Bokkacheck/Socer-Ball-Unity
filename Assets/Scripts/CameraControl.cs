using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private JoyStickCamera joyStickCamera;
    [SerializeField]
    private Camera myCamera;
    [SerializeField]
    private Rigidbody ball;
    private RaycastHit hit;
    private Material[] wallMaterials;
    void Start()
    {
        wallMaterials = new Material[GameObject.FindGameObjectsWithTag("Wall").Length];
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("Wall").Length;i++)
        {
            wallMaterials[i] = GameObject.FindGameObjectsWithTag("Wall")[i].GetComponent<Renderer>().material;
        }
    }
    void FixedUpdate()
    {
        transform.position = player.transform.position;
        float ballY = ball.position.y;
        if (ballY - player.transform.position.y > 10)
        {
            ballY /= 2;
        }
        Quaternion cameraRotate = Quaternion.LookRotation(new Vector3(ball.position.x,ballY,ball.position.z) - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotate,3*Time.deltaTime);
        //transform.rotation = Quaternion.Euler(new Vector3(0f,transform.rotation.eulerAngles.y+joyStickCamera.ChangeView()*2,0f));
        if (Physics.Raycast(myCamera.transform.position, GameObject.Find("CameraHelp").transform.forward, out hit,5f))
        {
            if (hit.collider != null&&hit.collider.tag == "Wall")
            {
                MaterialModeSwitch.SetupMaterialWithBlendMode(hit.collider.GetComponent<MeshRenderer>().material, MaterialModeSwitch.BlendMode.Transparent);
            }
            else
            {
                for (int i = 0; i <wallMaterials.Length; i++)
                {
                    MaterialModeSwitch.SetupMaterialWithBlendMode(wallMaterials[i], MaterialModeSwitch.BlendMode.Opaque);
                }
            }
        }
        else
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Wall").Length; i++)
            {
                MaterialModeSwitch.SetupMaterialWithBlendMode(wallMaterials[i], MaterialModeSwitch.BlendMode.Opaque);
            }
        }
    }
}
