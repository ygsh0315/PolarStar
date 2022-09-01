using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 북두칠성 그리기
// 구성 별 : Alkaid, Mizar, Alioth, Megrez, Phecda, Dubhe, Merak
// -> 구성 별을 배열로 넣을까아ㅏㅏ....? 각각의 위치를 지정
// 
// 필요한 별의 정보 : 적경, 적위, 겉보기 등급
// 적경들, 적위들, x, y, z들

public class BigDipper : MonoBehaviour
{
    List<GameObject> starList = new List<GameObject>();
    // GameObject[] stars = new GameObject[];   // 구성 별
    float[] ra = new float[] { 13.4732f, 13.2355f, 12.5401f, 12.1525f, 11.5349f, 11.0150f, 11.0343f };  // 구성 별들의 적경
    float[] dec = new float[] { 49.1848f, 54.5531f, 55.5735f, 57.0157f, 53.4141f, 56.2256f, 61.4503f };
        // 구성 별들의 적위

    public float r; // 천구의 반지름

    //float ra = 13.4732f;    // 적경
    //float dec = 49.1848f;   // 적위

    // 변환된 직교 좌표
    float x;
    float y;
    float z;

    void Start()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            starList.Add(transform.GetChild(i).gameObject);
        }
        DrawStar();

    }

    void Update()
    {
    }

    // 좌표 변경
/*    void SphereToCartesian(float ra, float dec)
    {
        dec = (Mathf.PI / 2) - dec;
        var rr = r * Mathf.Sin(dec);
        z = rr * Mathf.Cos(ra);
        x = rr * Mathf.Sin(ra);
        y = rr * Mathf.Cos(dec);

        print(dec);
        print(x);
    }*/

    // 도를 라디안으로
    //float deg2rad = 0.017453f;

    // 구면좌표를 직교좌표로
    void DrawStar()
    {
        for(int i = 0; i < starList.Count; i++)
        {
            // 적경 : -> 디그리 -> 라디안으로
            ra[i] = ra[i] * -15f * Mathf.PI / 180;

            // 적위 : 디그리 -> 라디안
            dec[i] = dec[i] * (Mathf.PI / 180);
            dec[i] = (Mathf.PI / 2) - dec[i];

            var rr = r * Mathf.Sin(dec[i]);
            z = rr * Mathf.Cos(ra[i]);
            x = rr * Mathf.Sin(ra[i]);
            y = r * Mathf.Cos(dec[i]);

            starList[i].transform.position = new Vector3(x, y, z);


        }
        // 적경 : -> 디그리 -> 라디안으로
        //ra = ra * -15f * Mathf.PI/180;
        
        // 적위 : 디그리 -> 라디안
        //dec = (Mathf.PI / 2) - dec;
        //dec = dec * Mathf.PI / 180;

        //var rr = r * Mathf.Sin(dec);
        //z = rr * Mathf.Cos(ra);
        //x = rr * Mathf.Sin(ra);
        //y = r * Mathf.Cos(dec);

    }

    // 
}
