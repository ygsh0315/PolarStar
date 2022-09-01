using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정 시간마다 별똥별을 생성하고 싶다.
// 화면 안에서 랜덤으로 위치를 지정하고 싶다.
public class KJH_StarManager : MonoBehaviour
{
    public GameObject starFactory;
    public float createTime = 5f;
    float currentTime = 0f;
    Transform player;
    public float angle = 45f;
    public float a = 50f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            // 별똥별 생성

            GameObject star = Instantiate(starFactory);
            transform.forward = player.forward;
            star.transform.forward = transform.forward;
            
            float angle = Random.Range(-10, 10);
            float y = Random.Range(5f, 20f);

            
            float posX = a * Mathf.Tan(angle);

            star.transform.position = transform.right * posX + transform.up * y + transform.forward * a;

            // 일정 각도 안에서만 별똥별이 생성되고 싶다.     
            // 각도를 알 때 위치를 알고 싶다.

            currentTime = 0f;
        }
    }
}
