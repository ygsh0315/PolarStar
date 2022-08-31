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
            print("별똥별 생성");

            GameObject star = Instantiate(starFactory);
            transform.forward = player.forward;
            star.transform.forward = transform.forward;

            //// 별똥별 위치 지정
            //// 화면 좌표 가져오기
            //// 오브젝트에 대한 월드좌표를 스크린 좌표로 변환 --> 화면 상 좌표
            //Vector3 spacePos = Camera.main.WorldToScreenPoint(star.transform.position);

            //// 화면 상 랜덤 좌표
            //float posX = Random.Range(0, Screen.width);
            //float posY = Random.Range(Screen.height / 2, Screen.height);

            //// 스크린 상 랜덤 좌표로 별 위치 지정
            //star.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(posX, posY, spacePos.z));


            // 2. atan 사용해서 시야각 안에 별똥별 생성되도록!!

            //Vector3 dir = transform.position - player.transform.position;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            //float angle = Random.Range(0f, 60f);
            //angle = 40f;
            //print(angle);
            
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
