using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StarRay : MonoBehaviour
{
    Ray starRay;
    RaycastHit starRayHitInfo;
    LayerMask layerMask;
    GameObject Player;
    float distance;
    bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        layerMask = LayerMask.GetMask("Earth");
        starRay = new Ray(transform.position, Vector3.zero);
        if(isSelected == true)
        {
            Physics.Raycast(starRay, out starRayHitInfo, 1000 ,layerMask);
            Debug.DrawRay(starRay.origin, (Vector3.zero - transform.position).normalized * 1000, Color.red);

        }
        
    }
}
