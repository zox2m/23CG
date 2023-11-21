/*
 * 2019-08-24
 * 
 * 
 *  유니티 손전등 스크립트
 *  F키로 점멸가능
 *  작성자: 서지민
 *  
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    //플래시의 움직임을 위한 코드 
    public float mouseXSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    Light flash_light;
    Transform tr;
    KeyCode[] KeyCode_List; //키코드값 케싱

    void Awake()
    {
        flash_light = GetComponent<Light>();
        tr = this.transform;

        Key_Depoly();
    }

    void Key_Depoly()
    {
        //키 배열
        KeyCode_List = new KeyCode[10];

        //코드값 케싱하기
        KeyCode_List[0] = KeyCode.F;
        KeyCode_List[1] = KeyCode.Escape;
    }

    // Update is called once per frame
    void Update()
    {
        //시야 따라다니도록 
        float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //F 입력시 꺼지도록
        KeyCode result = User_Input();

        if(result == KeyCode_List[0])
        {
            if( flash_light.enabled)
            {
                flash_light.enabled = false;
            }
            else
            {
                flash_light.enabled = true;
            }
        }
    }

    //무엇이 눌렸는가
    KeyCode User_Input()
    {
        KeyCode result = KeyCode_List[1];

        for (int i = 0; i < KeyCode_List.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode_List[i]))
            {
                result =  KeyCode_List[i];
            }
        }

        return result;

    }
}
