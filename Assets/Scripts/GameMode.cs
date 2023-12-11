using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public Dictionary<string, GameObject> OnlinePlayerInfo = new Dictionary<string, GameObject>(); //�¶��� �÷��̾���� ������ �����ϴ� ��ųʸ�
    [SerializeField]
    public GameObject LocalPlayer;
    public LocalPlayerManager LocalPMgr;

    [SerializeField]
    private GameObject OnlinePlayer;

    private void Start()
    {
        Screen.SetResolution(1280, 800, false);
        GetComponent<AudioSource>().volume = LocalPlayerManager.instance.MainSound;
        Camera.main.GetComponent<AudioSource>().volume = LocalPlayerManager.instance.EffectSound;
        LocalPMgr = GameObject.Find("PlayerManager").GetComponent<LocalPlayerManager>();
    }

    public void AddPlayerInfo(initDTO Key)
    {
        if (LocalPMgr.Nickname == "")
        { //ù ���� (���� �÷��̾� ���� ȹ��)
            Debug.Log("���� ����");
            LocalPMgr.Nickname = Key.nickname;
            LocalPMgr.Score = Key.score;
            LocalPMgr.isLogin = Key.islogin;
        }
        else if (OnlinePlayerInfo.ContainsKey(Key.nickname))
        { //�̹� �����ϴ� �÷��̾��� init�� ���� ��
            Debug.LogError("initfromReact: �̹� �����ϴ� �÷��̾�" + Key.nickname);   
        }
        else
        {//�÷��� ���� �� �÷��̾� ���� �� �÷��̾� ����
            GameObject OP = Instantiate(OnlinePlayer);
            OP.GetComponent<OnlinePlayerManager>().Nickname = Key.nickname;
            OP.GetComponent<OnlinePlayerManager>().Score = Key.score;
            OP.GetComponent<OnlinePlayerManager>().isLogin = Key.islogin;
            OP.GetComponent<OnlinePlayerManager>().SetName();
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
            OP.GetComponent<OnlinePlayerManager>().Nickname = Key.nickname;
            OP.GetComponent<OnlinePlayerManager>().Score = Key.score;
            OP.GetComponent<OnlinePlayerManager>().SetName();
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
    public void SetMainSound()
    {

    }
}
