using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRKeyEvent : MonoBehaviour
{
    public GameObject checkstat; // ����Ȯ�� �г�
    public Transform CPRplayer;
    public Transform cprspot;

    public bool is_statQ = false;


    private void Start()
    {
        checkstat.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        // Trigger ������ Stay ���� �� �г� Ȱ��ȭ
        if (other.CompareTag("CPRPlayer") && !is_statQ)
        {
            checkstat.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q) && !is_statQ)
            {
                is_statQ = true;
                checkstat.SetActive(false);
                CPRplayer.position = cprspot.position;
                CPRplayer.rotation = cprspot.rotation;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger���� �������� �� �г� ��Ȱ��ȭ
        if (other.CompareTag("CPRPlayer"))
        {
            checkstat.SetActive(false);
        }
    }
}
