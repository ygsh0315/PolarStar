using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPManager : MonoBehaviour
{
    public static HTTPManager instance;




    private void Awake()
    {
        // 만약에 instacne가 null이라면
        if(instance == null)
        {
            // instance에 나를 넣겠다.
            instance = this;
            // 씬이 전환이 되도 나를 파괴되지 않게 하겠다.
            DontDestroyOnLoad(gameObject);
        }
        // 그렇지 않으면
        else
        {
            // 나를 파괴하겠다.
            Destroy(gameObject);
        }
        
    }
    
    // 서버에게 요청
    // url(posts/1), GET
    public void SendRequest(HTTPRequester requester)
    {
        StartCoroutine(Send(requester));
    }

    IEnumerator Send(HTTPRequester requester)
    {
        UnityWebRequest webRequest = null;
        // requestType에 따라서 호출해줘야 한다.
        switch (requester.requestType)
        {
            case RequestType.POST:
                webRequest = UnityWebRequest.Post(requester.url, requester.postData);
                byte[] data = Encoding.UTF8.GetBytes(requester.postData);
                webRequest.uploadHandler = new UploadHandlerRaw(requester.postArray);
               // webRequest.SetRequestHeader("Content-Type", "application/json");

                break;
            case RequestType.GET:
                webRequest = UnityWebRequest.Get(requester.url);
                break;
            case RequestType.PUT:
                webRequest = UnityWebRequest.Put(requester.url, requester.postArray);
                //webRequest.SetRequestHeader("Content-Type", "application/json");
                break;
            case RequestType.DELETE:
                webRequest = UnityWebRequest.Delete(requester.url);
                break;
        }
        // 서버에 요청을 보내고 응답이 올때까지 기다린다.
        yield return webRequest.SendWebRequest();

        // 만약에 응답이 성공했다면
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // 완료되었다고 requester, onComplete를 실행
            print(webRequest.downloadHandler.text);

            //byte[] texData = texture2D.GetRawTextureData();
            //string texString = Encoding.UTF8.GetString(texData);

            requester.onComplete(webRequest.downloadHandler);
        }
        // 그렇지않다면
        else
        {
            // 서버통신 실패... ㅠ
            print("통신 실패" + webRequest.result + "\n" + webRequest.error);
        }
        yield return null;
    }
}
