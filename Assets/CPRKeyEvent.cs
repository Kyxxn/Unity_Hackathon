using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRKeyEvent : MonoBehaviour
{
    public GameObject cpr;

    public GameObject checkstat; // ����Ȯ�� �г�
    public Transform CPRplayer;
    public Transform cprspot;
    private CPRPlayerAnimation pa;
    public bool is_statQ = false;


    public GameObject cprstartpanel;

    private void Start()
    {
        checkstat.SetActive(false);
        pa = cpr.GetComponentInChildren<CPRPlayerAnimation>();
    }


    private void OnTriggerStay(Collider other)
    {
        // Trigger ������ Stay ���� �� �г� Ȱ��ȭ
        if (other.CompareTag("CPRPlayer") && !is_statQ)
        {
            checkstat.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q) && !is_statQ)
            {
                pa._isCPR = true;
                is_statQ = true;
                checkstat.SetActive(false);
                cprstartpanel.SetActive(true);
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
