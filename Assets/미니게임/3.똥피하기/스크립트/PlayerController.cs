using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        public float moveSpeed = 5f; // �̵� �ӵ� ���� ����
        public float stopTime = 2f; // ��ü ���� �� ���� ���ߴ� �ð� (��)
        public GameObject game_over;

        void Update()
        {
            // �¿� �̵� �Է� ó��
            float moveInput = Input.GetAxis("Horizontal");
            float moveAmount = moveInput * moveSpeed * Time.deltaTime;

            // �̵� ����
            transform.Translate(new Vector3(moveAmount, 0, 0));
  
        }

        // Ʈ���� ����
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                // Ʈ���ŷ� ������ ������Ʈ�� "Obstacle" �±׸� ������ �ְ� ������ �������� �ʴٸ� ���� ����
                StopGame();

                // ���� ���� �ؽ�Ʈ Ȱ��ȭ
                game_over.SetActive(true);
            }
        }

        // ���� ���� ó��
        void StopGame()
        {
            Time.timeScale = 0f;
            Invoke("ResumeGame", stopTime);
        }

}
