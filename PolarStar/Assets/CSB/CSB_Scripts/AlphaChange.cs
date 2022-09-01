using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlphaChange : MonoBehaviour
{
    Color color = new Color(1, 1, 1, 0);
    Color targetColor = new Color(1, 1, 1, 0.3f);
    bool isColorChange = false;
    Quaternion originRotation;

    KJH_AudioPlay ap;

    // Start is called before the first frame update
    void Start()
    {
        originRotation = transform.rotation;

        transform.forward = Vector3.zero - transform.position;

        // alpha º¯°æ
        transform.GetComponent<SpriteRenderer>().color = color;
        ap = GetComponent<KJH_AudioPlay>();
    }
    float curTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (ap.isStartSound)
        {
            //isColorChange = true;

            curTime += Time.deltaTime;

            if(curTime > ap.source.clip.length)
            {
                isColorChange = true;
            }
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

            KJH_SceneManager.instance.LoadWebCamScene();
            
        }
    }
}
