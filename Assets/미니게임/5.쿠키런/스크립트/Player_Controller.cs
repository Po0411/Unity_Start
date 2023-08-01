using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Player_Controller : MonoBehaviour
{
    public float jumpForce = 1f; // ���� �� ���� ����
    public float fastFallForce = 5f; // ������ �Ʒ��� �������� ��
    public GameObject game_over;

    private Rigidbody2D rb;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �����̽��� �Է� ó��
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
        // �Ʒ� ����Ű (S Ű) �Է� ó��
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * fastFallForce, ForceMode2D.Force);
        }
    }

    // �ٴڿ� ������ ���� ���¸� �ʱ�ȭ
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }


        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOver();
            // ���� ���� �ؽ�Ʈ Ȱ��ȭ
            game_over.SetActive(true);
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
    }
}
