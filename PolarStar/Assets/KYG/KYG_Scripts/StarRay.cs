using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StarRay : MonoBehaviour
{
    Ray starRay;
    RaycastHit starRayHitInfo;
    LayerMask layerMask;
    public GameObject Player;
    public GameObject Earth;
    float distance;
    bool isSelected = true;

    public static StarRay instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ////layerMask = LayerMask.GetMask("Earth");
        //starRay = new Ray(transform.position, Earth.transform.position - transform.position);
        //Vector3 dir = Vector3.zero - transform.position;

        //if(Physics.Raycast(starRay, out starRayHitInfo, 1000))
        //{
        //    if (Input.GetKeyDown(KeyCode.T))
        //    {
        //        Debug.DrawRay(starRay.origin, (Earth.transform.position - transform.position).normalized * 1000, Color.red);
        //        print(starRayHitInfo.point);
        //        Player.transform.position = starRayHitInfo.point;

        //        //Player.transform.up
        //    }
        //}
        
        
    }
    public void transfort(GameObject stars)
    {
        Transform trans = stars.transform.GetChild(0).transform;
        print(trans);
        if (!trans) return;

        //layerMask = LayerMask.GetMask("Earth");
        starRay = new Ray(trans.position, Earth.transform.position - trans.position);
        Vector3 dir = Vector3.zero - trans.position;

        if (Physics.Raycast(starRay, out starRayHitInfo, 1000))
        {
            //if (Input.GetKeyDown(KeyCode.T))
            //{
                Debug.DrawRay(starRay.origin, (Earth.transform.position - trans.position).normalized * 1000, Color.red);
                //print(starRayHitInfo.point);
                Player.transform.position = starRayHitInfo.point;

                //Player.transform.up
            //}
        }
    }
}
