using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate_move : MonoBehaviour
{
    public float MoveSpeed = 10;//������ ���� �ӵ� ��ġ]

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        Vector3 movemont = Vector3.zero;//���� �ʱ�ȭ.

        if (Input.GetAxis("Horizontal") > 0)//Horizontal�� ��ġ�� 0���� ũ��
        {
            movemont = Vector3.right;//���������� �̵� 
        }
        if (Input.GetAxis("Horizontal") < 0)//Horizontal�� ��ġ�� 0���� ������
        {
            movemont = Vector3.left;//�������� �̵�

        }

        if(transform.position.x<=-7.3)
        {
            transform.position = new Vector3(-7.3f, -4.6f, 0);
        }
        if (transform.position.x >= 7.3)
        {
            transform.position = new Vector3(7.3f, -4.6f, 0);
        }
            transform.position += movemont * MoveSpeed * Time.deltaTime;//���� ���� �̵� �ӵ��� ���ؼ� �̵��ϰ� ����.
    }
}
