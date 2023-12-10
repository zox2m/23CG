using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Range(0f,1f)]
    [SerializeField] private float waypointSize =0.5f;
    // 웨이 포인트 그리기. 기즈모 
    private void OnDrawGizmos()
    {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position,waypointSize);
        }

        Gizmos.color = Color.red;
        for(int i=0;i<transform.childCount-1;i++){
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }
        Gizmos.DrawLine(transform.GetChild(transform.childCount-1).position, transform.GetChild(0).position);
    }

    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if(currentWaypoint ==null)
        {
            //첫번째 웨이포인트로 초기화 
            return transform.GetChild(0);
        }
        
        //마지막값이 아니라면~ 다음 값 반환 
        if(currentWaypoint.GetSiblingIndex()< transform.childCount -1 )
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex()+1 );
        }
        // 마지막값이라면 첫번째 반환 
        else
        {
            return transform.GetChild(0);
        }
    }

}
