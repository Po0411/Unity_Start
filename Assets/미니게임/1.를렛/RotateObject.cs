using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float Speed = 0f; // ȸ�� �� �ӵ�

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))// ���콺 ���� Ŭ���� �ϸ� Speed = 10 �� ����
        {
            Speed = 10f;
        }


        this.transform.Rotate(0f, 0f, Speed *= 0.98f); // Speed = Speed * 0.98 �� ���� �ӵ��� ��������
        // transform.Rotate�� ����Ƽ���� �����ϴ� �Լ� �Դϴ�. �� ȸ�� �ϴ� �Լ� �Դϴ�
    }
}
