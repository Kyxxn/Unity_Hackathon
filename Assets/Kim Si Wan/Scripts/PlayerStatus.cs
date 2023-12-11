using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Slider HpBarSlider;
    public Text Debuff;
    private string debuffMsg = "";
    public int maxHp = 100;

    public int currentHp;
    public ItemMaker[] belongings;
    private int belongingsIndex = 0;

    public bool usedFood = false;
    public bool usedWater = false;
    public bool usedClothes = false;
    public bool usedFirstAid = false;
    public bool usedMask = false;
    public bool usedRadio = false;
    public bool usedBattery = false;
    public bool usedTape = false;
    public bool usedTowel = false;
    public bool usedFlashLight = false;
    void Start()
    {
        currentHp = maxHp;
        belongings = new ItemMaker[20];
    }

    public void setBelongings(ItemMaker itemMaker) {
        belongings[belongingsIndex++] = itemMaker;
    }
    public void deleteBelongings(ItemMaker itemMaker) {
        for (int i = 0; i < belongingsIndex; i++) {
            if (belongings[i].itemName == itemMaker.itemName) {
                belongings[i] = null;
                break;
            }
        }
        belongingsIndex--;
    }

    public void volcanicAshTime() {
    }
    public void gameover() {
        StopAllCoroutines();
        GameManager.instance.isGameover = true;
    }


    void checkHp()
    {
        if (HpBarSlider != null)
            HpBarSlider.value = currentHp / maxHp;
    }
    public void damage() //* damage
    {
        currentHp -= 5;
        checkHp(); //* ü�� ����
        if (currentHp <= 0)
        {
            // ���� ����
            gameover();
        }
    }

    
    /*void setDebuffMsg() {
        debuffMsg = "";
        if (isHungry == true) 
            debuffMsg += "�����, ";
        if (isThirsty == true)
            debuffMsg += "�񸶸�, ";
        if (isCold == true)
            debuffMsg += "�߿�, ";
        if (isSick == true)
            debuffMsg += "����, ";
        if (isAsh == true)
            debuffMsg += "ȭ����, ";
        if (isLightOut == true)
            debuffMsg += "����";
    }*/
}