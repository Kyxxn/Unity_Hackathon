using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CPRgameMode : MonoBehaviour
{
    public static CPRgameMode instance = null;
    void Awake()
    {
        instance = this;
    }

    //UI
    [SerializeField]
    public GameObject StartUI;

    public bool isPerfect = true;


    public GameObject ChestPanel;
    public GameObject DetailPlaying;
    public GameObject breathDetail;
    public GameObject BreathPanel;



    public GameObject cpr;
    private CPRPlayerAnimation pa;

    public GameObject Patient;
    private CPRKeyEvent ke;
    public PlayerHP_Bar HP;


    public GameObject ending;
    public Text endingscore;
    public Text endingresult;


    void Start()
    {
        StartUI.SetActive(false);
        ChestPanel.SetActive(false);
        DetailPlaying.SetActive(false);
        breathDetail.SetActive(false);
        BreathPanel.SetActive(false);
        ending.SetActive(false);


        pa = cpr.GetComponentInChildren<CPRPlayerAnimation>();
        ke = Patient.GetComponentInChildren<CPRKeyEvent>();

        HP = Patient.GetComponentInChildren<PlayerHP_Bar>();
        // 3�� �Ŀ� MyFunction �Լ� ����
        Invoke("start_setting", 3f);

    }

    public void start_setting()
    {
        Camera.main.GetComponent<CPRCameraMovement>().enabled = false;
        StartUI.SetActive(true);
    }

    public void StartBtn()
    {

        Camera.main.GetComponent<CPRCameraMovement>().enabled = true;
        StartUI.SetActive(false);

    }

    public void chestTruenext()
    {
        isPerfect = true;
        ChestPanel.SetActive(false);

        DetailPlaying.SetActive(true) ;
    }
    public void chestFalsenext()
    {
        ChestPanel.SetActive(false);
        isPerfect = false;
        DetailPlaying.SetActive(true);
    }

    public void chestDetail()
    {
        DetailPlaying.SetActive(false);
        BreathPanel.SetActive(true);
    }



    public void BreathTruenext()
    {
        BreathPanel.SetActive(false);

        breathDetail.SetActive(true);
    }
    public void BreathFalsenext()
    {
        BreathPanel.SetActive(false);
        isPerfect = false;
        breathDetail.SetActive(true);
    }

    public void breathDetailnext()
    {
        breathDetail.SetActive(false);
        pa._isCPR = false;
        ke.is_statQ = false;

        pa._isCPR = true;
        Invoke("CPR_anime", 3f);

        if(isPerfect)
        {
            Ending();
        }
    }

    public void Ending()
    {
        ending.SetActive(true);

        if(HP.currenthp < 50) // ���� 
        {
            endingscore.text = "��� : 5 �� �̻� �ҿ�\nsocre:50";
            endingresult.text = "������ ��� Ÿ���� �ƴ����� �׷��� �˸��� ����óġ�� �Ͽ����ϴ�\n �� ����� ������ ���߽��ϴ�!";
        }
        else if(HP.currenthp > 50 && HP.currenthp <= 100 ) // �ּ�
        {
            endingscore.text = "��� : 5 �� �̳� �ҿ�\nsocre:100\"";
            endingresult.text = "�����մϴ�!\n��Ȯ�ϰ� �ż��� ����óġ ���� \n �� ����� ������ ���߽��ϴ�!!";
        }
        else if(HP.currenthp == 0) // �־�
        {
            endingscore.text = "��� : 10 �� �ʰ�\nsocre:0";
            endingresult.text = "��Ȯ���� ���� ����óġ ������ �� ����� ����� ������ ���߽��ϴ�.\n ������ CPR ���̵带 �����Ͽ� �ּ���!";
        }

    }
    public void CPR_anime()
    {
        pa._isCPR = false;
    }



    public void ToLobbyBtn()
    {
        SceneManager.LoadScene("Lobby");
    }
}
