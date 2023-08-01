using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class ball_move : MonoBehaviour
{
    public Text scoreText;
    public Text Go_scoreText;
    public GameObject gameover_secen;

    Rigidbody2D rigid;
    int score;

    public float movespeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = rigid.position;
        rigid.MovePosition( pos + transform.up * movespeed * Time.deltaTime);
        
        scoreText.text = "Score: " + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "top_line")
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = 180f - tmp.z;
            transform.eulerAngles = tmp;
        }
        if (collision.transform.tag=="line")
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = 180f*2 - tmp.z;
            transform.eulerAngles = tmp;
        }
        if (collision.transform.tag == "plate")
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = Random.Range(-70f,70f);
            transform.eulerAngles = tmp;
        }
        if (collision.transform.tag == "block")
        {
            score += 300;
            Destroy(collision.gameObject);
            Vector3 tmp = transform.eulerAngles;
            tmp.z = Random.Range(-180f, 180f) - tmp.z;
            transform.eulerAngles = tmp;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "ded_line")
        {
            gameover_secen.SetActive(true);
            Go_scoreText.text = "Score: " + score;
            Time.timeScale = 0;
        }
    }
}
