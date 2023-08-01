using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class ball_move : MonoBehaviour
{
    public Text scoreText;//���ھ ǥ���� �ؽ�Ʈ
    public Text Go_scoreText;//���ӿ����� ���ھ ǥ���� �ؽ�Ʈ
    public GameObject gameover_secen;//���ӿ��� ��ũ��

    Rigidbody2D rigid;//���� ������ٵ�
    int score;//���ھ�

    public float movespeed = 10;//�� �̵��ӵ�
 
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();//���� ������ٵ� �ҷ���
    }

 
    void Update()
    {
        Vector3 pos = rigid.position;//������ٵ��� �������� ����
        rigid.MovePosition( pos + transform.up * movespeed * Time.deltaTime);//��� �̵��� �� �ֵ��� ����
        
        scoreText.text = "Score: " + score;//�ؽ�Ʈ�� ���ھ ǥ��
    }

    private void OnCollisionEnter2D(Collision2D collision)//�ݶ��̴��� ������Ʈ�� ��� ���̶��
    {
        if (collision.transform.tag == "top_line")//���� ������Ʈ�� �±װ� top_line��
        {
            Vector3 tmp = transform.eulerAngles;//tmp�� ���� ���Ϸ����� ����
            tmp.z = 180f - tmp.z;//���Ϸ������� z ���� 180�� �A ��ŭ�� ����
            transform.eulerAngles = tmp;//���� ���Ϸ����� ���� ���� ����
        }
        if (collision.transform.tag=="line")//���� ������Ʈ�� �±װ� line��
        {
            Vector3 tmp = transform.eulerAngles;//tmp�� ���� ���Ϸ����� ����
            tmp.z = 180f*2 - tmp.z;//���Ϸ������� z ���� 360�� �A ��ŭ�� ����
            transform.eulerAngles = tmp;//���� ���Ϸ����� ���� ���� ����
        }
        if (collision.transform.tag == "plate")//���� ������Ʈ�� �±װ� plate��
        {
            Vector3 tmp = transform.eulerAngles;//tmp�� ���� ���Ϸ����� ����
            tmp.z = Random.Range(-70f,70f);//-70~70������ ������ ������ ����
            transform.eulerAngles = tmp;//���� ���Ϸ����� ���� ���� ����
        }
        if (collision.transform.tag == "block")//���� ������Ʈ�� �±װ� block��
        {
            score += 300;//���ھ 300����
            Destroy(collision.gameObject);//���� ������Ʈ ����
            Vector3 tmp = transform.eulerAngles;//tmp�� ���� ���Ϸ����� ����
            tmp.z = Random.Range(-180f, 180f) - tmp.z;//-180~180������ ������ ������ ����
            transform.eulerAngles = tmp;//���� ���Ϸ����� ���� ���� ����
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)//�ݶ��̴��� ������Ʈ�� ����ϴ� ���̸�
    {
        if(collision.tag== "ded_line")//����� ������Ʈ�� �±װ� ded_line��
        {
            gameover_secen.SetActive(true);//���ӿ��� ��ũ�� Ȱ��ȭ
            Go_scoreText.text = "Score: " + score;//���ӿ��� ���ھ� �ؽ�Ʈ�� ���ھ� ����
            Time.timeScale = 0;//���� �ð��� ����
        }
    }
}
