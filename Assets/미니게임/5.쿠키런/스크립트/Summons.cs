using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summons : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ ������Ʈ ������
    public float spawnInterval = 1f; // ������Ʈ ���� ���� (��)
    private float timer = 0f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // ������ ������Ʈ ��ġ ����
        Vector3 spawnPosition = transform.position;

        // ������Ʈ�� �����մϴ�.
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // ���� �ð�(3��) �ڿ� ������ ������Ʈ�� ����
        Destroy(spawnedObject, 5f);
    }
}
