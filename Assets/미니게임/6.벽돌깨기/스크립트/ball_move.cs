using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class ball_move : MonoBehaviour
{
    public Text scoreText;//스코어를 표시할 텍스트
    public Text Go_scoreText;//게임오버시 스코어를 표시할 텍스트
    public GameObject gameover_secen;//게임오버 스크린

    Rigidbody2D rigid;//공의 리지드바디
    int score;//스코어

    public float movespeed = 10;//공 이동속도
 
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();//공의 리지드바디를 불러옴
    }

 
    void Update()
    {
        Vector3 pos = rigid.position;//리지드바디의 포지션을 대입
        rigid.MovePosition( pos + transform.up * movespeed * Time.deltaTime);//계속 이동할 수 있도록 적용
        
        scoreText.text = "Score: " + score;//텍스트에 스코어를 표시
    }

    private void OnCollisionEnter2D(Collision2D collision)//콜라이더에 오브젝트가 닿는 중이라면
    {
        if (collision.transform.tag == "top_line")//닿은 오브젝트의 태그가 top_line면
        {
            Vector3 tmp = transform.eulerAngles;//tmp에 공의 오일러각을 대입
            tmp.z = 180f - tmp.z;//오일러각도의 z 값에 180을 뺸 만큼을 대입
            transform.eulerAngles = tmp;//공의 오일러각에 변한 값을 대입
        }
        if (collision.transform.tag=="line")//닿은 오브젝트의 태그가 line면
        {
            Vector3 tmp = transform.eulerAngles;//tmp에 공의 오일러각을 대입
            tmp.z = 180f*2 - tmp.z;//오일러각도의 z 값에 360을 뺸 만큼을 대입
            transform.eulerAngles = tmp;//공의 오일러각에 변한 값을 대입
        }
        if (collision.transform.tag == "plate")//닿은 오브젝트의 태그가 plate면
        {
            Vector3 tmp = transform.eulerAngles;//tmp에 공의 오일러각을 대입
            tmp.z = Random.Range(-70f,70f);//-70~70까지의 랜덤한 각도를 대입
            transform.eulerAngles = tmp;//공의 오일러각에 변한 값을 대입
        }
        if (collision.transform.tag == "block")//닿은 오브젝트의 태그가 block면
        {
            score += 300;//소코어를 300증가
            Destroy(collision.gameObject);//닿은 오브젝트 삭제
            Vector3 tmp = transform.eulerAngles;//tmp에 공의 오일러각을 대입
            tmp.z = Random.Range(-180f, 180f) - tmp.z;//-180~180까지의 랜덤한 각도를 대입
            transform.eulerAngles = tmp;//공의 오일러각에 변한 값을 대입
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)//콜라이더가 오브젝트를 통과하는 중이면
    {
        if(collision.tag== "ded_line")//통과한 오브젝트의 태그가 ded_line면
        {
            gameover_secen.SetActive(true);//게임오버 스크린 활성화
            Go_scoreText.text = "Score: " + score;//게임오버 스코어 텍스트에 스코어 대입
            Time.timeScale = 0;//게임 시간을 멈춤
        }
    }
}
