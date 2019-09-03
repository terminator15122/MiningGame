using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Main : MonoBehaviour
{
    public Text upgradeTextUpgrade;
    public Text upgradeTextMiner;
    public Text upgradeTextStorage;

    public Text minerStorageText;
    public Text minerCountText;
    public Text upgradeCountText;
    public Text storageCountText;
         

    void Update()
    {
        upgradeTextUpgrade.text = Mathf.Round(MineManager.upgradeCost).ToString();
        upgradeTextMiner.text = Mathf.Round(MineManager.upgradeCostMiner).ToString();
        upgradeTextStorage.text = Mathf.Round(MineManager.upgradeCostStorage).ToString();

        minerStorageText.text = "Руды в хранилище: " + Mathf.Round(MineManager.minerStorage);
        minerCountText.text = "Шахтёров: " + MineManager.minerCount;
        upgradeCountText.text = "Улучшений шахты: " + MineManager.upgradeCount;
        storageCountText.text = "Улучшений хранилища: " + MineManager.storageUpgradeCount;
    }
       

    public void BuyUpgrade()
    {
        if (MineManager.upgradeCount < 30 && MineManager.minerStorage > MineManager.upgradeCost)
        {
            MineManager.upgradeCount++;
            MineManager.minerStorage -= MineManager.upgradeCost;
            MineManager.upgradeCost *= Mathf.Pow(MineManager.constant, MineManager.upgradeCount);
        }
    }


    public void BuyStorage()
    {
        if (MineManager.minerStorageMax < 1500 && MineManager.minerStorage > MineManager.upgradeCostStorage)
        {
            MineManager.minerStorageMax = MineManager.minerStorageMax + 50;
            MineManager.minerStorage -= MineManager.upgradeCostStorage;
            MineManager.upgradeCostStorage *= Mathf.Pow(MineManager.constant, MineManager.storageUpgradeCount);
            MineManager.storageUpgradeCount++;
        }
    }


    public void BuyMiner()
    {
        if (MineManager.minerCount < 30 && MineManager.minerStorage > MineManager.upgradeCostMiner)
        {
            MineManager.minerCount++;
            MineManager.minerStorage -= MineManager.upgradeCostMiner;
            MineManager.upgradeCostMiner *= Mathf.Pow(MineManager.constant, MineManager.minerCount);
        }
    }
}