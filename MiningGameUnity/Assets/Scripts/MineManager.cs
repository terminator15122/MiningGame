using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineManager : MonoBehaviour
{
    static public int minerCount;
    static public float minerStorage;
    static public float minerStorageMax;
    static public float upgradeCostMiner;
    static public float upgradeCost;
    static public float upgradeCostStorage;
    static public int upgradeCount;
    static public int storageUpgradeCount;
    static public float constant;


    void Start()
    {
        minerCount = 1;
        minerStorage = 0f;
        minerStorageMax = 100f;
        upgradeCostMiner = 10f;
        upgradeCost = 10f;
        upgradeCostStorage = 10f;
        upgradeCount = 1;
        storageUpgradeCount = 1;
        constant = 1.07f;
    }


    void Update()
    {
        if (minerStorage <= minerStorageMax)
        {
            minerStorage += (Time.deltaTime * minerCount * upgradeCount);
        }
        else
        {
            minerStorage = minerStorageMax;
        }
    }
}
