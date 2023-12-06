using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getObj : MonoBehaviour
{
    [SerializeField]
    private GameObject Obj;

    private void OnMouseDown()
    {
        StartCoroutine(ActivateObjectWithDelay()); // ��� �ð��� 2�ʷ� ���� (���ϴ� �ð����� ���� ����)
    }

    private IEnumerator ActivateObjectWithDelay()
    {
        Obj.SetActive(true);
        JSGameMode.instance.GuideText.text = Obj.name + " ȹ��";
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1);
        JSGameMode.instance.GuideText.text = "";
    }
}
