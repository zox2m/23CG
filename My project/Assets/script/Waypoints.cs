using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // 웨이 포인트 그리기. 기즈모 
    private void OnDrawGizmos()
    {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position,0.5f);
        }

        Gizmos.color = Color.red;
        for(int i=0;i<transform.childCount-1;i++){
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }
        Gizmos.DrawLine(transform.GetChild(transform.childCount-1).position, transform.GetChild(0).position);
    }

}
