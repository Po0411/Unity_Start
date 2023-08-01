using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset_bt : MonoBehaviour
{
    public void Onclick()
    {
        Time.timeScale = 1;//게임시간을 다시 흐르게 하고,
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//현재 씬을 다시 로드.
    }
}
