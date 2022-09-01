using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인식된 별자리의 색상을 바꾸고 싶다.
// 필요속성 : 바꿀 색상, 인식된 별자리의 인덱스

public class KJH_StarColorChange : MonoBehaviour
{
    int index;
    Color targetColor = new Vector4(1, 0.5f, 0, 1);
    Color getColor = new Vector4(0, 1, 0, 1);
    public bool isGetBadge = false;

    public static KJH_StarColorChange instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (isGetBadge)
        //{
        //    var main = ps.main;
        //    main.startColor = color;

        //    isGetBadge = false;
        //}

        // 통신이 성공되면 해당 인덱스의 별자리의 색상을 바꾼다.
    }

    void ChangeColor(Color color, ParticleSystem ps)
    {
        var main = ps.main;
        main.startColor = color;
    }

    // 통신 받은 별자리의 색상 변경하기
    public void HttpStarColorChange(GameObject stars)
    {
        for (int i = 0; i < stars.transform.childCount; i++)
        {
            ParticleSystem ps = stars.transform.GetChild(i).GetChild(0).GetComponent<ParticleSystem>();

            ChangeColor(targetColor, ps);
        }
    }

    //// 색상 변경하고 싶다.
    //public void DrawStarHttp(List<float> ra, List<float> dec, string name)
    //{

    //    for (int i = 0; i < ra.Count; i++)
    //    {
    //        star.transform.parent = go.transform;
    //        // 적경 : -> 디그리 -> 라디안으로
    //        ra[i] = ra[i] * -15f * Mathf.PI / 180;

    //        // 적위 : 디그리 -> 라디안
    //        dec[i] = dec[i] * (Mathf.PI / 180);
    //        dec[i] = (Mathf.PI / 2) - dec[i];

    //        var rr = r * Mathf.Sin(dec[i]);
    //        float z = rr * Mathf.Cos(ra[i]);
    //        float x = rr * Mathf.Sin(ra[i]);
    //        float y = r * Mathf.Cos(dec[i]);

    //        star.transform.position = Vector3.zero + new Vector3(x, y, z);
    //        //star.transform.position = new Vector3(x, y, z);
    //    }
    //}

}
