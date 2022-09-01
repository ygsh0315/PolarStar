using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //Campos 를 따라다니고 싶다.
    //필요속성 : campos, 속도

    public Transform campos;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Campos를 따라다니고 싶다.
        transform.position = Vector3.Lerp(transform.position, campos.position, speed * Time.deltaTime);
        //회전
        transform.rotation = Quaternion.Lerp(transform.rotation, campos.rotation, speed * Time.deltaTime);
    }
}
