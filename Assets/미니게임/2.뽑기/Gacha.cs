using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gacha : MonoBehaviour
{
    public string[] Gacha_List;//���� ���
    public Text result_text;//��� �ؽ�Ʈ
    public GameObject memo;//�޸�
    public GameObject reset_bt;//���¹�ư


    public void Onclick()//�̱� ��ư
    {
        result_text.text="�̱� ���\n"+Gacha_List[Random.Range(0, Gacha_List.Length)];//�迭�� �ε����� �������� ����.
        memo.SetActive(true);//������Ʈ Ȱ��ȭ
        reset_bt.SetActive(true);//������Ʈ Ȱ��ȭ
    }
    public void Onclick2()//�ٽ��ϱ� ��ư
    {
        memo.SetActive(false);//������Ʈ ��Ȱ��ȭ
        reset_bt.SetActive(false);//������Ʈ ��Ȱ��ȭ
    }
}
