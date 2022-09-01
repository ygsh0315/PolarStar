using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    //필요속성 : 회전속도
    public float rotSpeed = 205;



    //우리가 직접 각도를 관리하자
    float mx;
    float my;

    public bool bUseHorizontal = true;
    public bool bUseVertical = true;
    // Start is called before the first frame update
    void Start()
    {

        //시작할 때 사용자가 정해준 각도 값으로 세팅
        if (bUseHorizontal)
            mx = transform.eulerAngles.y;
        if (bUseVertical)
            my = -transform.eulerAngles.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //사용자의 마우스 입력에 따라 물체를 상하좌우로 회전시키고 싶다.
        //1. 사용자의 입력에 따라
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;
        //-60~ 60 으로 각도 제한걸기
        //x축 -> pitch, y축 -> Yaw, z축 -> Roll

        //float test = Vector3.Dot(Vector3.up, transform.up);
        //my = Mathf.Clamp(my, -60, 60);
        //transform.rotation *= Quaternion.AngleAxis(-v * rotSpeed * Time.deltaTime, transform.right);
        //transform.rotation *= Quaternion.AngleAxis(h * rotSpeed * Time.deltaTime, transform.up);

        //2. 방향이 필요하다.
        Vector3 dir = new Vector3(-my, mx, 0);

        //3. 회전하고 싶다.
        transform.eulerAngles = dir;

    }
    
    
}
