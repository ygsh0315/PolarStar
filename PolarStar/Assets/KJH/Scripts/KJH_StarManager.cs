using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// 일정 시간마다 별똥별을 생성하고 싶다.
// 화면 안에서 랜덤으로 위치를 지정하고 싶다.
public class KJH_StarManager : MonoBehaviour
{
    public GameObject starFactory;
    public float createTime = 5f;
    float currentTime = 0f;
    public Transform player;
    public float angle = 45f;
    public float a = 50f;


    public float radio = 300f;
    public float starAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            // 별똥별 생성
            GameObject star = Instantiate(starFactory);
            star.transform.position = Random.onUnitSphere * radio;
            currentTime = 0f;
        }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    HTTPRequester hTTPRequester = new HTTPRequester();

        //    hTTPRequester.url = "https://92c9-175-223-17-145.jp.ngrok.io/get_location";
        //    hTTPRequester.requestType = RequestType.GET;
        //    hTTPRequester.onComplete = CallBack;


        //    HTTPManager.instance.SendRequest(hTTPRequester);
        //}
    }

    //void CallBack(DownloadHandler downloadHandler)
    //{
    //    Constellation co = JsonUtility.FromJson<Constellation>(downloadHandler.text);
    //    print(co.name);
    //    print(co.index);


    //}
}
