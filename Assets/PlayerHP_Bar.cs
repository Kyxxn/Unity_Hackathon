using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP_Bar : MonoBehaviour
{
    public Transform player;
    public Slider hpbar;
    public float maxHp;
    public float currenthp;
    private float startTime; // Ÿ�̸� ���� �ð�
    public float elapsedTime; // ��� �ð�

    public GameObject CPRGameMode;
    private CPRgameMode gm;



    private void Start()
    {
        gm = CPRGameMode.GetComponentInChildren<CPRgameMode>();

        // Ÿ�̸� ���� �ð� �ʱ�ȭ
        startTime = Time.time;
        elapsedTime = 1f; // ���ϴ� �ð� �������� ����
    }

    void Update()
    {
        transform.position = player.position; // ���ʿ��� Vector3(0, 0, 0) ����

        if (Time.time - startTime >= elapsedTime)
        {
            startTime = Time.time;
            currenthp -= 1;
        }

        hpbar.value = currenthp / maxHp;
        if(currenthp == 0)
        {
            gm.Ending();
        }
    }
}
