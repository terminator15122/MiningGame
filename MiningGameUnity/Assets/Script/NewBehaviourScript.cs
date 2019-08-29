using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int MineConst;
    static private float MinerStorage;
    public int Miners;
    public int MinerMax;
    public float MinerUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        MineConst = 1;
        MinerUpgrade = 1;
        MinerStorage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (MinerStorage <= MinerMax)
        { 
        MinerStorage =( MinerStorage + (MineConst * Time.deltaTime * Miners * MinerUpgrade));
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 200, 50), "Кол-во куды в шахте: " + Mathf.Round(MinerStorage));
        GUI.Box(new Rect(0, 50, 200, 100), "Кол-во апгрейды: " + MinerUpgrade);
        GUI.Box(new Rect(0, 100, 200, 150), "Кол-во майнеров: " + Miners);
    }

    public void BuyUpgrade()
    {
        if (MinerUpgrade < 30 && MinerStorage > 5)
        {
            MinerUpgrade++;
            MinerStorage -= 5;
        }

    }
    public void BuyStorage()
    {
        if (MinerMax < 1500 && MinerStorage >50)
        {
            MinerMax = MinerMax + 50 ;
            MinerStorage -= 50;
        }

    }
    public void BuyMiner()
    {
        if (Miners < 30 && MinerStorage > 5)
        {
            Miners++;
            MinerStorage -= 5;
        }


    }
    }
