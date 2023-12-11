using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject ClosedWindow;
    [SerializeField]
    GameObject Playermodel;

    private void OnMouseDown()
    {
        float distance = Vector3.Distance(Playermodel.transform.position, transform.position);
        if (distance < 5)
        {
            JSGameMode.instance.Point += 10;
            StartCoroutine(JSGameMode.instance.SetGuideText("â���� �ݾҽ��ϴ�"));
            gameObject.SetActive(false);
            ClosedWindow.SetActive(true);
        }
    }
}

