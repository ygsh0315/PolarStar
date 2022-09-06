using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlphaChange : MonoBehaviour
{
    public static AlphaChange instance;
    Color color = new Color(1, 1, 1, 0);
    Color targetColor = new Color(1, 1, 1, 0.3f);
    public bool isColorChange = false;
    Quaternion originRotation;

    KJH_AudioPlay ap;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

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

            if (curTime > ap.source.clip.length)
            //if(curTime > 5f)
            {
                ap.source.Stop();
                isColorChange = true;
            }
        }

        if (isColorChange)
        {
            color = Color.Lerp(color, targetColor, Time.deltaTime * 0.4f);
            
            if(color.a > 0.25f)
            {
                color = targetColor;
                isColorChange = false;

                //KJH_SceneManager.instance.LoadWebCamScene();
            }

            GetComponent<SpriteRenderer>().color = color;

            
            
        }
    }
}
