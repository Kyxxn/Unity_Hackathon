using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerManager : MonoBehaviour
{
    public GameObject[] StrangerPrefab; // Stranger ������ �迭
    public Transform[] spawnPoints; // ���� ��ġ�� ������ �ִ� Transform �迭
    public float spawnInterval = 1.5f; // ���� ���� (3�ʷ� ����)
    public float spawnChance = 0.7f; // 5���� 1 Ȯ���� ���� (0.2�� ����)

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        // ���� �������� Ȯ���� üũ�Ͽ� Stranger ����
        if (timer >= spawnInterval)
        {
            timer = 0.0f;

            // Ȯ�� üũ
            if (Random.value <= spawnChance)
            {
                // ������ ��ġ ����
                int spawnIndex = Random.Range(0, spawnPoints.Length);

                // ������ Stranger ������ ����
                int prefabIndex = Random.Range(0, StrangerPrefab.Length);

                // ������ ��ġ�� Stranger ����
                Instantiate(StrangerPrefab[prefabIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
            }
        }
    }
}
