using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorHover : MonoBehaviour, IPointerClickHandler
{
    public GameObject player;
    public GameObject Btn;

    private Renderer rend;
    private Color originalColor;
    [SerializeField] private Color highlightColor = Color.white;


    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color; // ������ ������ ����
    }

    private void OnMouseEnter()
    {
        if (!player.GetComponent<PlayerStatus>().usedTowel)
        {
            rend.material.color = highlightColor; //��Ŀ���� ���̶���Ʈ ���� ����
        }
    }
    private void OnMouseExit()
    {
        if (!player.GetComponent<PlayerStatus>().usedTowel)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            rend.material.color = originalColor;
            Btn.SetActive(false);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!player.GetComponent<PlayerStatus>().usedTowel)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Vector3 mousePosition = Input.mousePosition;
                Btn.transform.position = mousePosition;
                Btn.SetActive(true);
            }
        }
    }

}
