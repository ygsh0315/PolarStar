using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 북극성 좌표로 찍어봄..!!
public class Polaris : MonoBehaviour
{
    public float r; // 천구의 반지름

    float ra = 2.3151f;
    float dec = 89.2114f;

    // 변환된 직교 좌표
    float x;
    float y;
    float z;

    void Start()
    {
        DrawStar();
    }

    void Update()
    {
        
    }

    void DrawStar()
    {
        
        // 적경 : -> 디그리 -> 라디안으로
        ra = ra * -15f * Mathf.PI / 180;

        // 적위 : 디그리 -> 라디안
        dec = dec * Mathf.PI / 180;
        dec = (Mathf.PI / 2) - dec;

        var rr = r * Mathf.Sin(dec);
        z = rr * Mathf.Cos(ra);
        x = rr * Mathf.Sin(ra);
        y = r * Mathf.Cos(dec);

        
        transform.position = new Vector3(x, y, z);


        

    }
}
