using System;
using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;

public class WebcamHandler : MonoBehaviour
{

    // 카메라 화면을 표시할 게임 오브젝트
    // 유니티 Inspector에서 지정되어야 함
    // 주의! Renderer 컴퍼넌트를 포함해야 함
    public GameObject objectTarget = null;

    // 카메라 입력을 위한 WebCamTexture
    protected WebCamTexture textureWebCam = null;

    public RawImage resultTexture;

    public RawImage rawImage;

    Renderer render;
    void Start()
    {
        rawImage.enabled = false;
        
        //StartCoroutine(GetTexture());
        // 현재 사용 가능한 카메라의 리스트
        WebCamDevice[] devices = WebCamTexture.devices;

        // 사용할 카메라를 선택
        // 가장 처음 검색되는 후면 카메라 사용
        int selectedCameraIndex = -1;
        for (int i = 0; i < devices.Length; i++)
        {
            // 사용 가능한 카메라 로그
            Debug.Log("Available Webcam: " + devices[i].name + ((devices[i].isFrontFacing) ? "(Front)" : "(Back)"));

            // 후면 카메라인지 체크
            if (devices[i].isFrontFacing == true)
            {
                // 해당 카메라 선택
                selectedCameraIndex = i;
                break;
            }
        }

        // WebCamTexture 생성
        if (selectedCameraIndex >= 0)
        {
            // 선택된 카메라에 대한 새로운 WebCamTexture를 생성
            textureWebCam = new WebCamTexture(devices[selectedCameraIndex].name);
            textureWebCam.Play();

            // 원하는 FPS를 설정
            if (textureWebCam != null)
            {
                textureWebCam.requestedFPS = 60;
            }
        }

        // objectTarget으로 카메라가 표시되도록 설정
        if (textureWebCam != null)
        {
            // objectTarget에 포함된 Renderer
            render = objectTarget.GetComponent<Renderer>();

            // 해당 Renderer의 mainTexture를 WebCamTexture로 설정
            render.material.mainTexture = textureWebCam;

            //GetTextureInfo();
            //Texture2D myTex = (Texture2D)render.material.mainTexture;
            //byte[] texData = myTex.GetRawTextureData();
            //string texString = Encoding.UTF8.GetString(texData);

            //// 데이터를 받았을 때
            //myTex.LoadRawTextureData(texData);
            //myTex.Apply();
        }
    }

    void OnDestroy()
    {
        // WebCamTexture 리소스 반환
        if (textureWebCam != null)
        {
            textureWebCam.Stop();
            WebCamTexture.Destroy(textureWebCam);
            textureWebCam = null;
        }
    }

    // Play 버튼이 눌렸을 때
    // 주의! 유니티 Inspector에서 버튼 연결 필요
    public void OnPlayButtonClick()
    {
        // 카메라 구동 시작
        if (textureWebCam != null)
        {
            textureWebCam.Play();
        }
    }

    // Stop 버튼이 눌렸을 때
    // 주의! 유니티 Inspector에서 버튼 연결 필요
    public void OnStopButtonClick()
    {
        // 카메라 구동 정지
        if (textureWebCam != null)
        {
            textureWebCam.Stop();
        }
    }

    public byte [] GetTextureInfo()
    {
        if (textureWebCam != null)
        {
            Texture mainTexture = render.material.mainTexture;
            Texture2D texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);

            RenderTexture currentRT = RenderTexture.active;

            RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
            Graphics.Blit(mainTexture, renderTexture);

            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();

            RenderTexture.active = currentRT;

            //byte[] texData = texture2D.GetRawTextureData();
            //string texString = Encoding.UTF8.GetString(texData);

            //File.WriteAllBytes(Application.dataPath + "/test.png", texture2D.EncodeToPNG());

            return texture2D.EncodeToPNG();
        }
        return null;
    }
    public bool isDownAlpha2 = false;

    void Update()
    {
        if(StarGuide.Instance.guideState == StarGuide.GuideState.state5)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                isDownAlpha2 = true;
            
                HTTPRequester hTTPRequester = new HTTPRequester();
                hTTPRequester.url = "https://a5f3-2001-2d8-e294-a769-b91e-b8f0-a69f-1491.jp.ngrok.io/get_picture";
                //hTTPRequester.url = URL.instance.sendImage;
                hTTPRequester.requestType = RequestType.POST;
                hTTPRequester.postData = "aa";// GetTextureInfo();
                hTTPRequester.postArray = GetTextureInfo();
                hTTPRequester.onComplete = CallBack; 


                HTTPManager.instance.SendRequest(hTTPRequester);

                StartCoroutine(GetTexture());
            }
        }
    }

    void CallBack(DownloadHandler downloadHandler)
    {
        /*
        //Constellation co = JsonUtility.FromJson<Constellation>(downloadHandler.text);
        //string data = downloadHandler.text.Substring("bytearray".Length);
        byte[] stringData = Convert.FromBase64String(downloadHandler.text);
        //byte[] data = Encoding.UTF8.GetBytes(downloadHandler.text);
        print($"byte Length: {stringData}"); 
        Texture2D tex = new Texture2D(1, 1, TextureFormat.RGBA32, false);
        //tex.LoadImage(stringData);
        tex.LoadRawTextureData(stringData);
        tex.Apply();
        resultTexture.material.mainTexture = (Texture)tex;

        Rect rect = new Rect(0, 0, tex.width, tex.height);
        //img.sprite = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f));
        byte[] d = tex.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/test.png", d);
        */
    }

    IEnumerator GetTexture()
    {
        
        yield return new WaitForSeconds(7.0f);

        rawImage.enabled = true;

        Uri address = new Uri("https://a5f3-2001-2d8-e294-a769-b91e-b8f0-a69f-1491.jp.ngrok.io/static/image/result.jpg");
        //Uri address = new Uri(URL.instance.receiveImage);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(address);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            resultTexture.texture = myTexture;
        }
    }
}
