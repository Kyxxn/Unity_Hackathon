using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemMaker itemMaker;

    public void useTool() {
        if (itemMaker.itemType == ItemMaker.ItemType.Equipment)
        {
            // ����

        }
        else if (itemMaker.itemType == ItemMaker.ItemType.Used)
        {
            // �ܼ� ����ȿ�� ���

        }
        else
        {
            // �ܺ� ��ü�� �ִ��� ������ �Ǵ� �� �ܺ� ��ü�� ���

            Debug.Log(itemMaker.itemName + " �� ����߽��ϴ�.");
            //SetSlotCount(-1);
        }

    }
}
