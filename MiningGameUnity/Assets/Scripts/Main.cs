using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Main : MonoBehaviour
{
    public Text upgradeTextUpgrade;
    public Text upgradeTextMiner;
    public Text upgradeTextStorage;
         

    void Update()
    {
        upgradeTextUpgrade.text = GameManager.upgradeCost.ToString();
        upgradeTextMiner.text = GameManager.upgradeCostMiner.ToString();
        upgradeTextStorage.text = GameManager.upgradeCostStorage.ToString();
    }


    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 200, 50), "Кол-во руды в шахте: " + Mathf.Round(GameManager.minerStorage));
        GUI.Box(new Rect(0, 50, 200, 50), "Кол-во апгрейды: " + GameManager.upgradeCount);
        GUI.Box(new Rect(0, 100, 200, 50), "Кол-во майнеров: " + GameManager.minerCount);
    }


    public void BuyUpgrade()
    {
        if (GameManager.upgradeCount < 30 && GameManager.minerStorage > GameManager.upgradeCost)
        {
            GameManager.upgradeCount++;
            GameManager.minerStorage -= GameManager.upgradeCost;
            GameManager.upgradeCost *= Mathf.Pow(GameManager.constant, GameManager.upgradeCount);
        }
    }


    public void BuyStorage()
    {
        if (GameManager.minerStorageMax < 1500 && GameManager.minerStorage > GameManager.upgradeCostStorage)
        {
            GameManager.minerStorageMax = GameManager.minerStorageMax + 50;
            GameManager.minerStorage -= GameManager.upgradeCostStorage;
            GameManager.upgradeCostStorage *= Mathf.Pow(GameManager.constant, GameManager.storageUpgradeCount);
            GameManager.storageUpgradeCount++;
        }
    }


    public void BuyMiner()
    {
        if (GameManager.minerCount < 30 && GameManager.minerStorage > GameManager.upgradeCostMiner)
        {
            GameManager.minerCount++;
            GameManager.minerStorage -= GameManager.upgradeCostMiner;
            GameManager.upgradeCostMiner *= Mathf.Pow(GameManager.constant, GameManager.minerCount);
        }
    }
}