using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Vector3 yVelocity = Vector3.zero;
    float gravity = -10;
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 중력이 정해질 방향을 구한다.
        Vector3 dir = (transform.position - target.position).normalized;


        // 2. 나의 위치에서 중력 방향으로 이동한다.
        transform.position += dir * gravity * Time.deltaTime;

        // 3. 나의 업 방향을 중력의 반대 방향으로 바꾼다.
        transform.up = dir * -1;

        
    }
}
