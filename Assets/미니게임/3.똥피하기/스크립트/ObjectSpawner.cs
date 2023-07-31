using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // 생성할 오브젝트 프리팹
    public float spawnInterval = 1f; // 오브젝트 생성 간격 (초)
    public float minX = -8.8f; // x 좌표의 최소값
    public float maxX = 8.84f; // x 좌표의 최대값
    public float spawnY = 5f; // y 좌표

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // 랜덤한 x 좌표 생성
        float randomX = Random.Range(minX, maxX);

        // 생성할 오브젝트 위치 설정
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        // 오브젝트를 생성합니다.
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // 일정 시간(3초) 뒤에 생성된 오브젝트를 삭제
        Destroy(spawnedObject, 3f);
    }
}
