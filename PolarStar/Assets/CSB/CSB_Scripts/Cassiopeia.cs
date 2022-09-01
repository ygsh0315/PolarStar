using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카시오페아 구성별 : Caph, Shedir, Navi, Ruchbah, Segin

public class Cassiopeia : MonoBehaviour
{
    List<GameObject> starList = new List<GameObject>();
    float[] ra = new float[] { 0.1024f, 0.4148f, 0.5806f, 1.2719f, 1.5603f };  // 구성 별들의 적경
    float[] dec = new float[] { 59.1621f, 56.3932f, 60.5010f, 60.2058f, 63.4638f };
    // 구성 별들의 적위

    public float r; // 천구의 반지름

    // 변환된 직교 좌표
    float x;
    float y;
    float z;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
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

    // 구면좌표를 직교좌표로
    void DrawStar()
    {
        for (int i = 0; i < starList.Count; i++)
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

    }
}
