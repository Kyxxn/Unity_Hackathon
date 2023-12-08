using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSPlayerMgr : MonoBehaviour
{
    [SerializeField]
    private JSGameMode JSGMode = JSGameMode.instance;

    private void OnParticleCollision(GameObject other)
    {
        if (!JSGMode.ActionObj[0].activeSelf)
        {
            Debug.Log("��ƼŬ �ĸ���");
            JSGMode.PHealth -= 1.5f;
        }
        else
        {
            Debug.Log("��ƼŬ �ĸ���");
            JSGMode.PHealth -= 0.05f;
        }
        if (JSGMode.PHealth <= 0)
        {
            gameObject.SetActive(false);
            //�÷��̾� �㱸��
            JSGMode.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndPoint")
        { //���Ӹ�� �̵�
            JSGMode.GameOver();
            enabled = false;
        }
    }
}
