using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// * 별똥별
// 일정 시간마다 대각선 아래로 떨어지고 싶다.
// 2. 대각선 아래 방향으로 이동한다.
// 2-1. 플레이어의 방향으로 떨어지지 않도록 각도 제한

public class KJH_ShootingStar : MonoBehaviour
{
    public float fallSpeed = 5f;
    Vector3 fallDir;

    public float removeTime = 3f;
    float currentTime = 0f;
    float randX, randY;

    // Start is called before the first frame update
    void Start()
    {
        randX = Random.Range(-90f, 90f);
        randY = Random.Range(-20f, -30f);
    }

    // Update is called once per frame
    void Update()
    {        
        // 일정시간이 지나면 없어지고 싶다.
        currentTime += Time.deltaTime;

        if(currentTime > removeTime)
        {
            // 크기를 줄이고 싶다.
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime);

            if ((transform.localScale - Vector3.one).magnitude < 0.1f)
            {
                Destroy(gameObject);
                currentTime = 0;
            }
        }

        // x좌표를 랜덤 좌표로 지정한다.
        fallDir.x = randX;
        fallDir.y = randY;

        // 방향을 랜덤으로 지정한다.
        transform.position += fallDir.normalized * fallSpeed * Time.deltaTime;


    }
}
