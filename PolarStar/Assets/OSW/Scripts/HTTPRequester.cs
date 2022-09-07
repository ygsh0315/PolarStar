using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class Constellation
{
    public string name;
    public int index;
}

public enum RequestType
{
    POST,
    GET,
    PUT,
    DELETE,
    IMAGE
}

public class HTTPRequester 
{
    // url
    public string url;
    // 요청 타입 (GET, POST, PUT, DELETE)
    public RequestType requestType;

    // Post Data
    public string postData; // (body)
    public byte[] postArray;
    

    // 응답이 왔을 때 호출해줄 함수(Action)
    // Action : 함수를 넣을 수 있는 자료형
    // 반환 자료형 void, 매개변수 없는 함수를 넣을 수 있다
    public Action<DownloadHandler> onComplete;

}
