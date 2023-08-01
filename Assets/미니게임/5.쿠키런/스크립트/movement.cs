using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절 변수

    void Update()
    {
        // 왼쪽으로 이동
        float moveAmount = -moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveAmount, 0, 0));
    }
}
