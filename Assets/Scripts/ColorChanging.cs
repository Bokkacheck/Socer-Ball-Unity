using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    // Start is called before the first frame update
    private Color color = new Color(0.5f, 0.5f, 0.5f);
    private float increment = 1 / 51f;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(ChangeColor());
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            if (color.r>=1||color.r<=0)
            {
                increment = -increment;
            }
            color.r  = color.g = color.b+= increment;
            rend.material.color = color;
        }
    }
    

}
