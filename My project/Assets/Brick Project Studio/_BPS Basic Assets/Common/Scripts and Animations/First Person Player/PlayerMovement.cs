using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
    public class PlayerMovement : MonoBehaviour
    {
        private GameManager gameManager;

        public Transform cameraTransform;
        public CharacterController characterController;

        public float moveSpeed = 5f; // 이동 속도
        public float jumpSpeed = 5f; // 점프 속도
        public float gravity = -15f; // 중력
        public float yVelocity = 0;

        // Vector3 velocity;

        bool isGrounded;

        // Update is called once per frame
        void Update()
        {
            //if(gameManager.isGameOver == true) Debug.Log("움직임 멈추기 "); 
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(x, 0, z);

            moveDirection = cameraTransform.TransformDirection(moveDirection);

            moveDirection *= moveSpeed;

            if (characterController.isGrounded) // 만약 characController 가 땅에 붙어있다면
            {
                yVelocity = 0;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    yVelocity = jumpSpeed;
                }
            }

            yVelocity += gravity * Time.deltaTime;

            moveDirection.y = yVelocity;

            characterController.Move(moveDirection * Time.deltaTime);

        }
    }
}