using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JSGameMode : MonoBehaviour
{
    public static JSGameMode instance = null;
    void Awake()
    {
        instance = this;
    }

    //UI
    [SerializeField]
    public GameObject StartUI;
    
    [SerializeField]
    public GameObject PlayUI;
    public Text GuideText;

    [SerializeField]
    public GameObject EndUI;

    //GAS
    [SerializeField]
    private ParticleSystem[] Gas;

    //ActionObj
    [SerializeField]
    public GameObject[] ActionObj;

    public Slider HP;
    public float PHealth;
    private Text HPtxt;

    private float TimeCount = 0;
    public int Point = 0;
    private float Rating = 0;

    [SerializeField]
    private AudioSource SirenAudio;
    [SerializeField]
    private AudioSource ExplosionAudio;

    void Start()
    {
        StartUI.GetComponentInChildren<Button>().onClick.AddListener(StartBtn);

        GuideText = PlayUI.transform.Find("GuideText").GetComponent<Text>();
        PHealth = 100;
        HP.value = PHealth;

        HPtxt = HP.GetComponentInChildren<Text>();
        if (PHealth >= 0)
        {
            HPtxt.text = "HP: " + PHealth.ToString("#.##");
        }
        else
        {
            HPtxt.text = "HP: 0";
        }
        EndUI.GetComponentInChildren<Button>().onClick.AddListener(ToLobbyBtn);
    }

    // Update is called once per frame
    void Update()
    {
        HP.value = PHealth;
        HPtxt.text = "HP: " + PHealth.ToString("#.##");
    }

    private IEnumerator SirenStartCoroutine()
    {
        yield return new WaitForSeconds(3);
        //5�� ���
        //���̷� Ű��
        SirenAudio.enabled = true;
        //���� �ڷ�ƾ ����
        StartCoroutine(GasStartCoroutine());
    }

    private IEnumerator GasStartCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            GuideText.text = "ȭ���� ���±��� " + (10 - i).ToString() + "��";
            yield return new WaitForSeconds(1);
        }
        GuideText.text = "ȭ���� ���±��� " + (0).ToString() + "��";
        yield return new WaitForSeconds(1);
        GuideText.text = "";
        ExplosionAudio.Play();
        for (int i = 0; i < Gas.Length; i++)
        {
            Gas[i].Play();
        }
    }

    public IEnumerator SetGuideText(string str)
    {
        GuideText.text = str;
        yield return new WaitForSeconds(1.5f);
        GuideText.text = "";
    }

    public void GameOver()
    {
        SirenAudio.enabled = false;
        PlayUI.SetActive(false);
        EndUI.SetActive(true);
        //endui ����
        Rating = PHealth - (Time.realtimeSinceStartup - TimeCount) + Point;
        Text Result = EndUI.transform.Find("ResultText").GetComponent<Text>();
        Result.text = "    ��\nü��: " + PHealth.ToString("#.##") +
                        "\n�ð�: " + (Time.realtimeSinceStartup - TimeCount).ToString("#.##") +
                        "\n����: " + Point.ToString() + " \n\n���� ���\n";

        //������ ���� �� ���
        //ü�� 100, ���� 170
        if(PHealth < 0)
        {
            Result.text += "F";
        }
        else if(Rating > 200)
        {
            Result.text += "S";
        }
        else if(Rating > 150)
        {
            Result.text += "A";
        }
        else if( Rating > 100)
        {
            Result.text += "B";
        }
        else
        {
            Result.text += "C";
        }
        Time.timeScale = 0;
        Camera.main.GetComponent<CameraMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void StartBtn()
    {
        Camera.main.GetComponent<CameraMovement>().enabled = true;
        StartUI.SetActive(false);
        PlayUI.SetActive(true);
        TimeCount = Time.realtimeSinceStartup;
        StartCoroutine(SirenStartCoroutine());
    }

    private void ToLobbyBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
    }
}
