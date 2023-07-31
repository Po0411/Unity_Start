using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        public float moveSpeed = 5f; // 이동 속도 조절 변수
        public float stopTime = 2f; // 물체 감지 시 게임 멈추는 시간 (초)
        public GameObject game_over;

        void Update()
        {
            // 좌우 이동 입력 처리
            float moveInput = Input.GetAxis("Horizontal");
            float moveAmount = moveInput * moveSpeed * Time.deltaTime;

            // 이동 적용
            transform.Translate(new Vector3(moveAmount, 0, 0));
  
        }

        // 트리거 감지
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                // 트리거로 감지된 오브젝트가 "Obstacle" 태그를 가지고 있고 게임이 멈춰있지 않다면 게임 멈춤
                StopGame();

                // 게임 오버 텍스트 활성화
                game_over.SetActive(true);
            }
        }

        // 게임 멈춤 처리
        void StopGame()
        {
            Time.timeScale = 0f;
            Invoke("ResumeGame", stopTime);
        }

}
