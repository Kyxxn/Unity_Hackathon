using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerMovement : MonoBehaviour
{
    public Transform target; // ��ǥ ��ġ�� ����Ű�� Transform
    public float moveSpeed = 5.0f; // �̵� �ӵ� ����

    private void Update()
    {
        // ���� target�� �����Ǿ� ���� �ʴٸ�, lastpoint�� ã�Ƽ� �Ҵ�
        if (target == null)
        {
            GameObject lastpoint = GameObject.Find("lastPoint");

            if (lastpoint != null)
            {
                target = lastpoint.transform;
            }
            else
            {
                Debug.LogError("lastpoint�� ã�� �� �����ϴ�.");
                return;
            }
        }
        // ĳ���͸� ��ǥ ��ġ�� �̵���Ű�� �ڵ�
        if (target != null)
        {
            // ��ǥ ��ġ�� ���� ��ġ�� ���̸� ���� (y���� 0���� ����)
            Vector3 targetPosition = new Vector3(target.position.x, 0.0f, target.position.z);
            Vector3 currentPosition = new Vector3(transform.position.x, 0.0f, transform.position.z);
            Vector3 direction = (targetPosition - currentPosition).normalized;

            // ĳ������ ��ġ�� ��ǥ �������� �̵�
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
