using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorHover : MonoBehaviour
{
    public GameObject player;
    public GameObject Btn;
    public GameObject Use;
    public GameObject Towel;

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
            rend.material.color = originalColor;
        }
    }
    private void OnMouseDown() {
        if (!player.GetComponent<PlayerStatus>().usedTowel)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Vector3 mousePosition = Input.mousePosition;
            Btn.transform.position = mousePosition;

            Use.GetComponent<DoorButton>().Towel = Towel;
            Btn.SetActive(true);
        }
    }

}
