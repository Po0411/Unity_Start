using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float MoveSpeed=10;//������ ���� �ӵ� ��ġ
    public float jumppower=10;//���� �� �� �� ���� ��ġ.

    public GameObject gameover;// ���ӿ��� ��
    public GameObject goal;// ���� ��
    public GameObject camera_obj;// ī�޶�

    bool is_jump=false;//���� �ߴ��� �� �ߴ��� �ľ�
    Rigidbody2D rigid;// �÷��̾��� ������ٵ�

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();//������ٵ� �ҷ���
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }
    void move()//�̵� �Լ�
    {
        Vector3 movemont=Vector3.zero;//���� �ʱ�ȭ.

        if (Input.GetAxis("Horizontal")>0)//Horizontal�� ��ġ�� 0���� ũ��
        {
           movemont = Vector3.right;//���������� �̵� 
            gameObject.transform.eulerAngles = new Vector2(0, 0);//ĳ���͸� ���������� ����.
        }
        if (Input.GetAxis("Horizontal") < 0)//Horizontal�� ��ġ�� 0���� ������
        {
            movemont = Vector3.left;//�������� �̵�
            gameObject.transform.eulerAngles = new Vector2(0,-180);//ĳ���͸� �������� ����.

        }
        transform.position += movemont *MoveSpeed* Time.deltaTime ;//���� ���� �̵� �ӵ��� ���ؼ� �̵��ϰ� ����.
    }
    void jump()//���� �Լ�
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!is_jump)//�����̽��� ������,�������� �ƴ϶��
        {
            is_jump = true;//���� ������ �ٲٰ�,
            rigid.AddForce(Vector3.up*jumppower,ForceMode2D.Impulse);//�÷��̾��� ������ٵ� �����ϴ� �� ��ŭ y���� ����.
        }
        else
        {
            return;//�������̸� �ٽ� ���ư�.
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//�ݶ��̴��� ������Ʈ�� ��� ���̶��
    {
        if(collision.transform.tag=="grund")//���� ������Ʈ�� �±װ� ground��
        {
            is_jump = false;//���� �ϴ� ���� �ƴ�
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//�ݶ��̴��� ������Ʈ�� ����ϴ� ���̸�
    {
        if (collision.transform.tag == "damge")//����� ������Ʈ�� �±װ� damge��
        {
            gameover.SetActive(true);//���ӿ��� �� Ȱ��ȭ.
            Time.timeScale = 0;//���� �ð��� ����
        }
        if (collision.transform.tag == "arrive")//����� ������Ʈ�� �±װ� damge��
        {
            goal.SetActive(true);//Ŭ���� �� Ȱ��ȭ.
            Time.timeScale = 0;//���� �ð��� ����
        }
    }

/*    void camera_move()//ī�޶� �÷��̾ ���󰡰� ����
    {
         
        if (transform.position.y <=0)//�÷��̾��� y���� 0�̰ų� 0���� �۴ٸ�
        {
            camera_obj.transform.position = new Vector3(transform.position.x, 1, -1);//ī�޶� �÷��̾��� x���� �޾ƿ���,y���� 1�� ����.
        }
        else
        {
            camera_obj.transform.position = new Vector3(transform.position.x, transform.position.y + 1, -1);//ī�޶� �÷��̾��� x���� y���� �޾ƿ�.
        }
    }*/
    public void onclick()//Ŭ���Ǿ��� �� �ߵ� �� �Լ�.(�ٽ��ϱ� ��ư)
    {
        Time.timeScale = 1;//���ӽð��� �ٽ� �帣�� �ϰ�,
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//���� ���� �ٽ� �ε�.
    }
}
