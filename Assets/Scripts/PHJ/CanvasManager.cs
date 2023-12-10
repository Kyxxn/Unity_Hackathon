using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    
    public Button GameStart;
    public GameObject Lobbybtn;
    public GameObject StartPanel; // 인스펙터에서 할당할 옵션 패널
    public GameObject GamePanel; // 인스펙터에서 할당할 옵션 패널
    private bool isOpen = false;

    void Start()
    {
        GameStart.onClick.AddListener(GameOpen); // 리스너 추가
        Lobbybtn.SetActive(false);
        GamePanel.SetActive(false);
    }

    void GameOpen()
    {
        Lobbybtn.SetActive(true);
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
}