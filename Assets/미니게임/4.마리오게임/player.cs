using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float MoveSpeed=10;
    public float jumppower=10;

    public GameObject gameover;
    public GameObject goal;

    bool is_jump=false;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }
    void move()
    {
        Vector3 movemont=Vector3.zero;

        if (Input.GetAxis("Horizontal")>0)
        {
           movemont = Vector3.right;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            movemont = Vector3.left;
        }
        transform.position += movemont *MoveSpeed* Time.deltaTime ;
    }
    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!is_jump)
        {
            is_jump = true;
            rigid.AddForce(Vector3.up*jumppower,ForceMode2D.Impulse);
        }
        else
        {
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="grund")
        {
            is_jump = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "damge")
        {
            gameover.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.transform.tag == "arrive")
        {
            goal.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void onclick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
