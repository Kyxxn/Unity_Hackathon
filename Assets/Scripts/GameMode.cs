using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public Dictionary<string, GameObject> OnlinePlayerInfo = new Dictionary<string, GameObject>(); //�¶��� �÷��̾���� ������ �����ϴ� ��ųʸ�
    [SerializeField]
    private GameObject LocalPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
