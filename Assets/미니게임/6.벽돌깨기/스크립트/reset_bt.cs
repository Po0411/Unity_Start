using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset_bt : MonoBehaviour
{
    public void Onclick()
    {
        Time.timeScale = 1;//���ӽð��� �ٽ� �帣�� �ϰ�,
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//���� ���� �ٽ� �ε�.
    }
}
