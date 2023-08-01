using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gacha : MonoBehaviour
{
    public string[] Gacha_List;//뽑을 목록
    public Text result_text;//결과 텍스트
    public GameObject memo;//메모
    public GameObject reset_bt;//리셋버튼


    public void Onclick()//뽑기 버튼
    {
        result_text.text="뽑기 결과\n"+Gacha_List[Random.Range(0, Gacha_List.Length)];//배열의 인덱스를 랜덤으로 결정.
        memo.SetActive(true);//오브젝트 활성화
        reset_bt.SetActive(true);//오브젝트 활성화
    }
    public void Onclick2()//다시하기 버튼
    {
        memo.SetActive(false);//오브젝트 비활성화
        reset_bt.SetActive(false);//오브젝트 비활성화
    }
}
