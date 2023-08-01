using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate_move : MonoBehaviour
{
    public float MoveSpeed = 10;//움직일 때의 속도 수치]

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
        Vector3 movemont = Vector3.zero;//벡터 초기화.

        if (Input.GetAxis("Horizontal") > 0)//Horizontal의 수치가 0보다 크면
        {
            movemont = Vector3.right;//오른쪽으로 이동 
        }
        if (Input.GetAxis("Horizontal") < 0)//Horizontal의 수치가 0보다 작으면
        {
            movemont = Vector3.left;//왼쪽으로 이동

        }

        if(transform.position.x<=-7.3)
        {
            transform.position = new Vector3(-7.3f, -4.6f, 0);
        }
        if (transform.position.x >= 7.3)
        {
            transform.position = new Vector3(7.3f, -4.6f, 0);
        }
            transform.position += movemont * MoveSpeed * Time.deltaTime;//받은 힘과 이동 속도를 곱해서 이동하게 만듬.
    }
}
