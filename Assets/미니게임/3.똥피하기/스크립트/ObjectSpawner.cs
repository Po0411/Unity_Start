using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ ������Ʈ ������
    public float spawnInterval = 1f; // ������Ʈ ���� ���� (��)
    public float minX = -8.8f; // x ��ǥ�� �ּҰ�
    public float maxX = 8.84f; // x ��ǥ�� �ִ밪
    public float spawnY = 5f; // y ��ǥ

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // ������ x ��ǥ ����
        float randomX = Random.Range(minX, maxX);

        // ������ ������Ʈ ��ġ ����
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        // ������Ʈ�� �����մϴ�.
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // ���� �ð�(3��) �ڿ� ������ ������Ʈ�� ����
        Destroy(spawnedObject, 3f);
    }
}
