using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class pianoClick : MonoBehaviour
    {
        public GameObject piano_ui; //피아노 건반
        public GameObject player;
        public Camera camera;

        public void Start(){
            piano_ui.SetActive(false);
        }
        public void OnMouseDown() {
            if (QuestPiano.PianoResult == false && ObjectClicker.uiIsActived == false) {
                Debug.Log("click piano");
                piano_ui.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
                camera.GetComponent<MouseLook>().enabled = false;
                ObjectClicker.uiIsActived = true;
            } else if (piano_ui.activeSelf == true) {
                Debug.Log("piano ui is already active");
            } else {
                Debug.Log("Success piano quest");
            }
        }
        
        public void ClosePianoUi() {
            Debug.Log("close painting hint ui");
            piano_ui.SetActive(false); // 힌트 UI 비활성화
            player.GetComponent<PlayerMovement>().enabled = true;
            camera.GetComponent<MouseLook>().enabled = true;
            ObjectClicker.uiIsActived = false;
        }
        
        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                ClosePianoUi();
            }
        }
    }
}
