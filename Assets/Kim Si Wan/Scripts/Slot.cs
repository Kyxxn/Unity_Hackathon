using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public ItemMaker itemMaker;         // Item inform object
    public int itemCount;               // Pickup item count
    public Image itemImage;             // Item image

    [SerializeField]
    private Text text_Count;            // Slot item count text
    [SerializeField]
    private GameObject go_CountImage;   // CountImage
    [SerializeField]
    private GameObject player;            // player

    [SerializeField]
    private GameObject ItemDescription;   // ItemDescription
    [SerializeField]
    private GameObject Panel;             // ItemDescription
    [SerializeField]
    private Text descriptionText;   // ItemDescription

    private bool isEnter = false;
    // Set itemImage's transparency
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // Add item to inventory
    public void AddItem(ItemMaker _itemmaker, int _count = 1)
    {
        itemMaker = _itemmaker;
        itemCount = _count;
        itemImage.sprite = itemMaker.itemImage;

        if (itemMaker.itemType != ItemMaker.ItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        player.GetComponent<PlayerStatus>().setBelongings(itemMaker.itemName);

        SetColor(1);
    }

    // Set slot item count
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    // Delete Slot
    private void ClearSlot()
    {
        itemMaker = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        itemImage.gameObject.SetActive(false);
        go_CountImage.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (itemMaker != null)
        {
            isEnter = true;
            Vector3 descriptionPos = new Vector3(this.transform.position.x + 67, this.transform.position.y - 67, this.transform.position.z);
            ItemDescription.transform.position = descriptionPos;
            descriptionText.text = "\n" + itemMaker.itemDescription + "\n\n��Ŭ�� �� ���";
            Panel.SetActive(true);
        }
    }

    // Click slot event
    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (itemMaker != null)
            {
                if (itemMaker.itemType == ItemMaker.ItemType.Equipment)
                {
                    // ����

                }
                else if (itemMaker.itemType == ItemMaker.ItemType.Used)
                {
                    // �ܼ� ����ȿ�� ���
                    Debug.Log(itemMaker.itemName + " �� ����߽��ϴ�.");
                    SetSlotCount(-1);
                }
                else
                {
                    // �ܺ� ��ü�� �ִ��� ������ �Ǵ� �� �ܺ� ��ü�� ���
                    Debug.Log(itemMaker.itemName + " �� ����߽��ϴ�.");
                    SetSlotCount(-1);
                }
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isEnter == true) {
            isEnter = false;
            Panel.SetActive(false);
        }
    }
}

