using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float MoveSpeed=10;//움직일 때의 속도 수치
    public float jumppower=10;//점프 할 때 줄 힘의 수치.

    public GameObject gameover;// 게임오버 씬
    public GameObject goal;// 도착 씬
    public GameObject camera_obj;// 카메라

    bool is_jump=false;//점프 했는지 안 했는지 파악
    Rigidbody2D rigid;// 플레이어의 리지드바디

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();//리지드바디를 불러옴
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }
    void move()//이동 함수
    {
        Vector3 movemont=Vector3.zero;//벡터 초기화.

        if (Input.GetAxis("Horizontal")>0)//Horizontal의 수치가 0보다 크면
        {
           movemont = Vector3.right;//오른쪽으로 이동 
            gameObject.transform.eulerAngles = new Vector2(0, 0);//캐릭터를 오른쪽으로 돌림.
        }
        if (Input.GetAxis("Horizontal") < 0)//Horizontal의 수치가 0보다 작으면
        {
            movemont = Vector3.left;//왼쪽으로 이동
            gameObject.transform.eulerAngles = new Vector2(0,-180);//캐릭터를 왼쪽으로 돌림.

        }
        transform.position += movemont *MoveSpeed* Time.deltaTime ;//받은 힘과 이동 속도를 곱해서 이동하게 만듬.
    }
    void jump()//점프 함수
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!is_jump)//스페이스가 눌리고,점프중이 아니라면
        {
            is_jump = true;//점프 중으로 바꾸고,
            rigid.AddForce(Vector3.up*jumppower,ForceMode2D.Impulse);//플레이어의 리지드바디에 점프하는 힘 만큼 y값을 곱함.
        }
        else
        {
            return;//점프중이면 다시 돌아감.
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//콜라이더에 오브젝트가 닿는 중이라면
    {
        if(collision.transform.tag=="grund")//닿은 오브젝트의 태그가 ground면
        {
            is_jump = false;//점프 하는 중이 아님
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//콜라이더가 오브젝트를 통과하는 중이면
    {
        if (collision.transform.tag == "damge")//통과한 오브젝트의 태그가 damge면
        {
            gameover.SetActive(true);//게임오버 씬 활성화.
            Time.timeScale = 0;//게임 시간을 멈춤
        }
        if (collision.transform.tag == "arrive")//통과한 오브젝트의 태그가 damge면
        {
            goal.SetActive(true);//클리어 씬 활성화.
            Time.timeScale = 0;//게임 시간을 멈춤
        }
    }

/*    void camera_move()//카메라가 플레이어를 따라가게 만듬
    {
         
        if (transform.position.y <=0)//플레이어의 y값이 0이거나 0보다 작다면
        {
            camera_obj.transform.position = new Vector3(transform.position.x, 1, -1);//카메라가 플레이어의 x값을 받아오고,y값은 1로 고정.
        }
        else
        {
            camera_obj.transform.position = new Vector3(transform.position.x, transform.position.y + 1, -1);//카메라가 플레이어의 x값과 y값을 받아옴.
        }
    }*/
    public void onclick()//클릭되었을 떄 발동 할 함수.(다시하기 버튼)
    {
        Time.timeScale = 1;//게임시간을 다시 흐르게 하고,
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//현재 씬을 다시 로드.
    }
}
