using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class supriseEvent : MonoBehaviour
{
    public GameObject Q_panel;

    public Text q_text;

    private bool is_119 = false;


    // Start is called before the first frame update


    void Start()
    {
        q_text.text = "";
    }

    private void OnTriggerStay(Collider other)
    {
        // Trigger ������ Stay ���� �� �г� Ȱ��ȭ
        if (other.CompareTag("CPRPlayer") && !is_119)
        {
            Q_panel.SetActive(true);
            if((Input.GetKeyDown(KeyCode.Q) && !is_119))
            {
                q_text.text = "��ȭ �Ϸ�";
                is_119 = true;
                Invoke("RMtxt", 1f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Trigger���� �������� �� �г� ��Ȱ��ȭ
        if (other.CompareTag("CPRPlayer"))
        {
            Q_panel.SetActive(false);
        }
    }
    public void RMtxt()
    {
        q_text.text = "";
    }
}
