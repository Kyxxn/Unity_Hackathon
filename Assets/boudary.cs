using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boudary : MonoBehaviour
{
    // �浹 �߻� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� �±װ� "stranger"�� ��� �ı�
        if (other.CompareTag("stranger"))
        {
            Destroy(other.gameObject);
        }
    }
}
