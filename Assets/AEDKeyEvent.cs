using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEDKeyEvent : MonoBehaviour
{

    public GameObject AEDKeyPanel; // AED ���� �г�

    public bool has_AED = false; //AED ���� ����

    public GameObject personBagAED; // ��ڿ� AED

    public GameObject Patient; // ȯ��
    private CPRKeyEvent ke;


    private void Start()
    {
        AEDKeyPanel.SetActive(false);
        personBagAED.SetActive(false);
        ke = Patient.GetComponentInChildren<CPRKeyEvent>();
    }


    private void OnTriggerStay(Collider other)
    {
        // Trigger ������ Stay ���� �� �г� Ȱ��ȭ
        if (other.CompareTag("CPRPlayer") && !has_AED)
        {

            AEDKeyPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q) && !has_AED)
            {
                has_AED = true;
                ke.has_AED= true;
                personBagAED.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger���� �������� �� �г� ��Ȱ��ȭ
        if (other.CompareTag("CPRPlayer"))
        {
            AEDKeyPanel.SetActive(false);
        }
    }
}
