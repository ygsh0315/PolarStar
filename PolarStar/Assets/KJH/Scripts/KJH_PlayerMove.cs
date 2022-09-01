using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 앞뒤좌우로 움직이고 싶다.
public class KJH_PlayerMove : MonoBehaviour
{
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0f;

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime);
        }
    }
}
