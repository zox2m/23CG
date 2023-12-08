using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_patrol : MonoBehaviour
{
    Rigidbody rb;
    Transform target;
    [Header("추격 속도")]
    [SerializeField] [ Range(1f,4f)] float moveSpeed =3f;
    [Header("근접 거리")]
    [SerializeField] [ Range(0f,3f)] float contactDistance =1f;
    bool follow = false;

    //start
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 컴포넌트 연결 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // player의 트랜스폼 값 가져옴 
    }
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime); 앞으로 움직임 
        FollowTarget();
    }

    void FollowTarget()
    {
        if(Vector3.Distance(transform.position,target.position) > contactDistance &&follow){
            transform.position = Vector3.MoveTowards(transform.position, target.position,moveSpeed*Time.deltaTime);

            //타겟 방향보기 
            Vector3 dir = target.transform.position - this.transform.position;

            
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * moveSpeed);
        }
        else   
            rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider collision)
    {
        follow = true;
    }

    private void OnTriggerExid(Collider collision)
    {
        follow = false;
    }
}
