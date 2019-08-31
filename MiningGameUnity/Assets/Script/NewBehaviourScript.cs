using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    public int mineConst;
    static private float minerStorage;
    public int miners;
    public int minerMax;
    public float minerUpgrade;
    public float upgradeCostRab;
    public float upgradeCostUp;
    public float upgradeCostStor;
    private float n;
    private float k;
    private float y;
    public float constan;
    public Text upgradeTextUp;
    public Text upgradeTextRab;
    public Text upgradeTextStor;
    string upgradeCostUpstr;
    string upgradeCostRabstr;
    string upgradeCostStorstr;


    void Start()
    {
        mineConst = 1;
        minerUpgrade = 1;
        minerStorage = 0;
        upgradeCostRab = 5;
        upgradeCostStor = 50;
        upgradeCostUp = 5;
        n = 1;
        k = 1;
        y = 1;
        constan = 2;
        minerMax = 200;
    }


    void Update()
    {
        if (minerStorage <= minerMax)
        {
            minerStorage = (minerStorage + (mineConst * Time.deltaTime * miners * minerUpgrade));
        }
        upgradeTextUp.text = upgradeCostRabstr;
        upgradeTextRab.text = upgradeCostStorstr;
        upgradeTextStor.text = upgradeCostUpstr;
    }


    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 200, 50), "Кол-во куды в шахте: " + Mathf.Round(minerStorage));
        GUI.Box(new Rect(0, 50, 200, 50), "Кол-во апгрейды: " + minerUpgrade);
        GUI.Box(new Rect(0, 50, 200, 50), "Кол-во майнеров: " + miners);
    }


    public void BuyUpgrade()
    {
        if (minerUpgrade < 30 && minerStorage > upgradeCostUp)
        {
            minerUpgrade++;
            minerStorage -= upgradeCostUp;
            n++;
            upgradeCostUp *= Mathf.Pow(constan, n);
            upgradeCostUpstr = upgradeCostUp.ToString();
        }
    }


    public void BuyStorage()
    {
        if (minerMax < 1500 && minerStorage > upgradeCostStor)
        {
            minerMax = minerMax + 50;
            minerStorage -= upgradeCostStor;
            y++;
            upgradeCostStor *= Mathf.Pow(constan, y);
            upgradeCostStorstr = upgradeCostStor.ToString();
        }
    }


    public void BuyMiner()
    {
        if (miners < 30 && minerStorage > upgradeCostRab)
        {
            miners++;
            minerStorage -= upgradeCostRab;
            upgradeCostRab *= Mathf.Pow(constan, k);
            upgradeCostRabstr = upgradeCostRab.ToString();
        }
    }
}