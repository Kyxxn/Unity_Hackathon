using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public GameObject Camera;
    public GameObject player;
    public Text GuideText;
    public Text TimeText;

    public GameObject startUi;

    public GameObject playUi;
    public GameObject canvasManager;

    public GameObject endUi;
    public Text resultText;

    public bool isPrepareTime = false;
    public bool isvolcanioAshTime = false;
    public bool isCleanningTime = false;
    public bool isGameover = false;

    public int countDownTime = 30;

    public GameObject Volcano;
    public Vector3 VolcanoPos;
    public Vector3 VolcanoCameraPos;
    public Vector3 VolcanoCameraRot;
    public Vector3 DefaultCameraPos;
    public Vector3 DefaultCameraRot;

    public string PermitUseItemName;

    public int MAX_SCORE = 1000;
    public int finalScore;
    public void startPlay() {
        StartCoroutine(Play());
    }
    IEnumerator Play()
    {
        // ���� �� �����ð�
        Camera.GetComponent<CameraMovement>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(8f);

        // ȭ�� ����
        GameObject VolcanoObject = Instantiate(Volcano);
        VolcanoObject.transform.position = VolcanoPos;

        Camera.GetComponent<CameraMovement>().enabled = false;
        Camera.transform.position = VolcanoCameraPos;
        Camera.transform.rotation = Quaternion.Euler(VolcanoCameraRot);
        yield return new WaitForSeconds(8f);

        // ȭ���� �����غ� �ð�
        string guidText = "ȭ���簡 �������� ���� ��ó�ϼ���!";
        Camera.GetComponent<CameraMovement>().enabled = true;
        isPrepareTime = true;
        GuideText.text = guidText;
        while (countDownTime > 0)
        {
            TimeText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }

        // ȭ���� ���� �ð�

        /*
        isvolcanioAshTime = true;
        gameInformPanel.SetActive(true);
        gameInformText.text = */

        /*
        guidText = "ȭ���簡 �������Դϴ�.\n���ظ� �ּ�ȭ�ϼ���!";
        isvolcanioAshTime = true; countDownTime = 180;
        GuideText.text = guidText;
        player.GetComponent<PlayerStatus>().volcanicAshTime();
        while (countDownTime > 0)
        {
            TimeText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;

            if (countDownTime == 100){
                player.GetComponent<PlayerStatus>().isCold = true;
            }
            else if (countDownTime == 50){
                player.GetComponent<PlayerStatus>().isSick = true;
            }

            if (isGameover == true)
                break;
        }
        */
        
    }

    // ���� ���
    void end() {
        isvolcanioAshTime = false;
        int finalHp = player.GetComponent<PlayerStatus>().currentHp;
        int surviveTime = 180 - countDownTime;
        finalScore = surviveTime * 2 + finalHp;

        char rank;
        if (finalScore <= 460 && finalScore > 360)
            rank = 'A';
        else if (finalScore <= 360 && finalScore > 260)
            rank = 'B';
        else if (finalScore <= 260 && finalScore > 160)
            rank = 'B';
        else//else if (finalScore <= 160)
            rank = 'D';

        resultText.text = "<���>\n\nü�� : " + "<color=red>" + finalHp + "</color>"
            + "\n�ð� : " + "<color=red>" + surviveTime + "</color>"
            + "\n\n���� : " + "<color=red>" + finalScore + "</color>"
            + "\n\n���� ��� : " + rank;
        playUi.SetActive(false);
        endUi.SetActive(true);
    }
}