using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SojaExiles
{
public class Letter_hint : MonoBehaviour
    {
        public GameObject letterHintUI; // 새 힌트 UI
        public GameObject player;
        public Camera camera;

        // 오디오 소스 추가 
        private AudioSource audioSource;
        private AudioClip drawerOpenSound;

        public void Start(){
            letterHintUI.SetActive(false);
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
        
        public void OnMouseDown() {
            if (ObjectClicker.uiIsActived == false) {
                Debug.Log("click Painting");
                letterHintUI.SetActive(true); // 힌트 UI 활성화

                this.audioSource.Play();
                player.GetComponent<PlayerMovement>().enabled = false;
                camera.GetComponent<MouseLook>().enabled = false;
                ObjectClicker.uiIsActived = true;
            }
        }
        
        public void CloseLetterHint() {
            Debug.Log("close painting hint ui");
            letterHintUI.SetActive(false); // 힌트 UI 비활성화

            
            player.GetComponent<PlayerMovement>().enabled = true;
            camera.GetComponent<MouseLook>().enabled = true;
            ObjectClicker.uiIsActived = false;
        }
        
        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                CloseLetterHint();
            }
        }
    }        
}