using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public Dictionary<string, GameObject> OnlinePlayerInfo = new Dictionary<string, GameObject>(); //�¶��� �÷��̾���� ������ �����ϴ� ��ųʸ�
    [SerializeField]
    private GameObject LocalPlayer;
    [SerializeField]
    private GameObject OnlinePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayerInfo(initDTO Key)
    {
        if(OnlinePlayerInfo.Count == 0)
        { //ù ���� (���� �÷��̾� ���� ȹ��)
            Debug.Log("���� ����");
            LocalPlayer.GetComponent<PlayerManager>().Nickname = Key.nickname;
            LocalPlayer.GetComponent<PlayerManager>().Score = Key.score;
            LocalPlayer.GetComponent<PlayerManager>().isLogin = Key.islogin;
        }
        else if (OnlinePlayerInfo.ContainsKey(Key.nickname))
        { //�����ϴ� �÷��̾� init ���� ��
            Debug.LogError("initfromReact: �̹� �����ϴ� �÷��̾�" + Key.nickname);
        }
        else
        {//�÷��� ���� �� �÷��̾� ���� �� �÷��̾� ����
            GameObject OP = Instantiate(OnlinePlayer);
            OP.GetComponent<PlayerManager>().Nickname = Key.nickname;
            OP.GetComponent<PlayerManager>().Score = Key.score;
            OP.GetComponent<PlayerManager>().isLogin = Key.islogin;
            OP.transform.position = new Vector3(-120, 0, -120);
            OnlinePlayerInfo.Add(Key.nickname, OP);
        }
    }

    public void UpdatePlayerInfo(PlayerDTO Key)
    {
        if (OnlinePlayerInfo.ContainsKey(Key.nickname))
        {//�÷��̾� ���� ������Ʈ
            OnlinePlayerInfo[Key.nickname].transform.position = new Vector3(Key.pos_x, Key.pos_y, Key.pos_z);
            OnlinePlayerInfo[Key.nickname].transform.rotation = Quaternion.Euler(Key.rot_x, Key.rot_y, Key.rot_z);
            OnlinePlayerInfo[Key.nickname].GetComponent<PlayerAnimation>().UpdateStat(Key.is_walk, Key.is_run, Key.is_jump);
        }
        else
        {//ó�� ���� �� �κ� �ִ� �÷��̾� ����
            GameObject OP = Instantiate(OnlinePlayer);
            OP.GetComponent<PlayerManager>().Nickname = Key.nickname;
            OP.GetComponent<PlayerManager>().Score = Key.score;
            OP.transform.position = new Vector3(Key.pos_x, Key.pos_y, Key.pos_z);
            OP.transform.rotation = Quaternion.Euler(Key.rot_x, Key.rot_y, Key.rot_z);
            OP.GetComponent<PlayerAnimation>().UpdateStat(Key.is_walk, Key.is_run, Key.is_jump);
            OnlinePlayerInfo.Add(Key.nickname, OP);
        }
    }

    public void DeletePlayerInfo(initDTO Key)
    {
        Destroy(OnlinePlayerInfo[Key.nickname]);
        OnlinePlayerInfo.Remove(Key.nickname);
    }
}
