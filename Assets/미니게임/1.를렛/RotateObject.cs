using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float Speed = 0f; // 회전 할 속도

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))// 마우스 왼쪽 클릭을 하면 Speed = 10 이 대입
        {
            Speed = 10f;
        }


        this.transform.Rotate(0f, 0f, Speed *= 0.98f); // Speed = Speed * 0.98 즉 점점 속도가 느려진다
        // transform.Rotate은 유니티에서 지원하는 함수 입니다. 즉 회전 하는 함수 입니다
    }
}
