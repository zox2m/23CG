using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_move : MonoBehaviour
{
    // 추적을 위한 값들 
    Rigidbody rb;
    Transform target;
    [Header("추격 속도")]
    [SerializeField] [ Range(1f,4f)] float traceSpeed =1f;
    
    [Header("추적 거리")]
    [SerializeField] [ Range(0f,3f)] float traceDistance =1f;

    // 이 객체에서 사용할 웨이오핀트 참조 
    [SerializeField] private Waypoints waypoints;

    //기본 이동 속도
    [Header("기본 속도")]
    [SerializeField] private float moveSpeed = 1f;

    //웨이포인트와의 거리 
    [SerializeField] private float distanceThreshold = 0.1f;

    // 현재 타겟이 되는 웨이포인트 
    private Transform currentWaypoint;

    //start
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 컴포넌트 연결 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // player의 트랜스폼 값 가져옴 

        // 웨이포인트 1번으로 이동 
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //다음 웨이포인트를 타겟으로 정하기 
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);

        // 웨이포인트 타겟 지점 바라보기 
        transform.LookAt(currentWaypoint);
    }
    
    void Update()
    {
        // 플레이어가 추적 범위 내에 있다면
        if(Vector3.Distance(transform.position,target.position) < traceDistance){
            FollowTarget();
        }

        //아니라면~ patrol 
        else{
            transform.LookAt(currentWaypoint);

            transform.position = Vector3.MoveTowards(transform.position,currentWaypoint.position,moveSpeed * Time.deltaTime);

            if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
            }
        }       

    }

    void FollowTarget()
    {
        // 플레이어 방향으로 움직이기 
        transform.position = Vector3.MoveTowards(transform.position, target.position,traceSpeed*Time.deltaTime);
        
        //타겟 방향보기 
        transform.LookAt(target);

    }
}
