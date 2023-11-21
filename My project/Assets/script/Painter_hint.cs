using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SojaExiles
{
public class Painter_hint : MonoBehaviour
    {
        public GameObject quizHintUI; // 새 힌트 UI
        public GameObject player;
        public Camera camera;
        
        public void Start(){
            quizHintUI.SetActive(false);
        }
        
        public void OnMouseDown() {
            if (ObjectClicker.uiIsActived == false) {
                Debug.Log("click Painting");
                quizHintUI.SetActive(true); // 힌트 UI 활성화
                player.GetComponent<PlayerMovement>().enabled = false;
                camera.GetComponent<MouseLook>().enabled = false;
                ObjectClicker.uiIsActived = true;
            }
        }
        
        public void ClosePaintingHint() {
            Debug.Log("close painting hint ui");
            quizHintUI.SetActive(false); // 힌트 UI 비활성화
            player.GetComponent<PlayerMovement>().enabled = true;
            camera.GetComponent<MouseLook>().enabled = true;
            ObjectClicker.uiIsActived = false;
        }
        
        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                ClosePaintingHint();
            }
        }
    }        
}