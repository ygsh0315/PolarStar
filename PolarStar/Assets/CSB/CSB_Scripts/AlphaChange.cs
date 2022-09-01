using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlphaChange : MonoBehaviour
{
    Color color = new Color(1, 1, 1, 0);
    Color targetColor = new Color(1, 1, 1, 0.3f);
    bool isColorChange = false;
    Quaternion originRotation;

    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.rotation;

        transform.forward = Vector3.zero - transform.position;



        // alpha º¯°æ
        transform.GetComponent<SpriteRenderer>().color = color;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isColorChange = true;
        }

        if (isColorChange)
        {
            color = Color.Lerp(color, targetColor, Time.deltaTime * 0.1f);
            
            if(color.a > 0.27f)
            {
                color = targetColor;
                isColorChange = false;
            }

            GetComponent<SpriteRenderer>().color = color;
        }
    }
}
