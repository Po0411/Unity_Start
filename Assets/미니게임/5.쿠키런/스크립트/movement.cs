using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ���� ����

    void Update()
    {
        // �������� �̵�
        float moveAmount = -moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveAmount, 0, 0));
    }
}
