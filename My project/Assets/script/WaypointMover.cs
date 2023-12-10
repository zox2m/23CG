using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    // 이 객체에서 사용할 웨이오핀트 참조 
    [SerializeField] private Waypoints waypoints;

    //속도
    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private float distanceThreshold = 0.1f;

    // 현재 타겟이 되는 웨이포인트 
    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        // 웨이포인트 1번으로 이동 
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //다음 웨이포인트를 타겟으로 정하기 
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);

        // 타겟 지점 바라보기 
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,currentWaypoint.position,moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }
    }
}
