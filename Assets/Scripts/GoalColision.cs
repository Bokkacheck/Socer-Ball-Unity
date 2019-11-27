using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalColision : MonoBehaviour
{
    [SerializeField]
    private GameObject center;
    [SerializeField]
    private Text text;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
            other.transform.position = center.transform.position;
            text.text = (int.Parse(text.text) + 1).ToString();
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
