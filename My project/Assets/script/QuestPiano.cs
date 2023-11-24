using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace SojaExiles
{
    public class QuestPiano : MonoBehaviour
    {
        private bool Correct = false;
        public static bool PianoResult = false;
        public TextMeshProUGUI Result;
        public Button[] Note = new Button[12];
        private int[] answer = new int[4] { 4, 7, 1, 2 };
        private int[] input = new int[4] { -1, -1, -1, -1 };
        private string[] str = new string[12] {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
        int n=0;

        public GameObject piano_ui; //피아노 건반
        public GameObject player;
        public Camera camera;

        [SerializeField] private float displayResultTime = 1f;
        
        private void Start()
        {
            piano_ui.SetActive(false);
            for (int i = 0; i < 12; i++)
            {
                int index = i;
                Note[index].interactable = true;
                Note[index].onClick.AddListener(() => this.TaskOnClick(index));
            }
        }
        
        public void OnMouseDown() {
            if (PianoResult == false && ObjectClicker.uiIsActived == false) {
                Debug.Log("click piano");
                piano_ui.SetActive(true);
                player.GetComponent<PlayerMovement>().enabled = false;
                camera.GetComponent<MouseLook>().enabled = false;
                ObjectClicker.uiIsActived = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } 
        }
        
        private void TaskOnClick(int index)
        {
            Debug.Log("입력 : " + index, Note[index]);
            if (n > 4)
                return;
            if(n == 0)
                Result.text = "";
            input[n++] = index;
            Result.text += str[index] + " ";
            
            // 입력이 완료되면 정답 확인
            // 마지막은 '시'를 눌러야된다는 힌트 넣기
            if (n == 4) {
                
                PrintFinish(); // 정답 확인
            }
        }

        public void PrintFinish()
        {
            Debug.Log("Finish Button Click");
            Correct = true;
            for(int i=0; i < 4; i++)
            {
                if(answer[i] != input[i]) Correct = false;
            }
            if(Correct) {
                // 문제 풀기 성공
                Result.text = "Success";
                // GameObject.Find("piano_ui").SetActive(false);
                PianoResult = true;
                // 1초 기다리고 닫힘
                StartCoroutine(ClosePianoAfterDelay());
                opencloseDoor3.door1Open = true;
            }
            else  // 문제 풀기 실패
                Result.text = "Fail";
                 n = 0;
                for (int i = 0; i < 4; i++)
                    input[i] = -1;
        }
        
        private IEnumerator ClosePianoAfterDelay()
        {
            yield return new WaitForSeconds(displayResultTime);
            ClosePiano();
        }
        
        public void PrintReset()
        {
            Debug.Log("Reset Button Click");
            Result.text = "Reset";
            n = 0;
            for (int i = 0; i < 4; i++)
                input[i] = -1;
        }
        
        public void ClosePiano() {
            Debug.Log("close piano ui");
            piano_ui.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
            camera.GetComponent<MouseLook>().enabled = true;
            ObjectClicker.uiIsActived = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}