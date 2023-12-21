using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerManager : MonoBehaviour
{
    public GameObject[] StrangerPrefab; // Stranger ������ �迭
    public Transform[] spawnPoints; // ���� ��ġ�� ������ �ִ� Transform �迭
    public float spawnInterval = 0.1f; // ���� ���� (3�ʷ� ����)
    private float spawnChance = 0.7f; // 5���� 1 Ȯ���� ���� (0.2�� ����)

    public Transform[] targetPoinsts;



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
                GameObject instance = Instantiate(StrangerPrefab[prefabIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
                instance.GetComponent<StrangerMovement>().target = targetPoinsts[Random.Range(0, targetPoinsts.Length)];
                
            }
        }
    }
}
