using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summons : MonoBehaviour
{
    public GameObject objectToSpawn; // 생성할 오브젝트 프리팹
    public float spawnInterval = 1f; // 오브젝트 생성 간격 (초)
    private float timer = 0f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // 생성할 오브젝트 위치 설정
        Vector3 spawnPosition = transform.position;

        // 오브젝트를 생성합니다.
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // 일정 시간(3초) 뒤에 생성된 오브젝트를 삭제
        Destroy(spawnedObject, 5f);
    }
}
