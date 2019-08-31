using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public int MineConst;
    static private float MinerStorage;
    public int Miners;
    public int MinerMax;
    public float MinerUpgrade;
    public float UpgradeCostRab;
    public float UpgradeCostUp;
    public float UpgradeCostStor;
    private float n;
    private float k;
    private float y;
    public float constan;
    public Text upgradeText1;
    public Text upgradeText2;
    public Text upgradeText3;
    string UpgradeCostUpstr;
    string UpgradeCostRabstr;
    string UpgradeCostStorstr;
    // Start is called before the first frame update
    void Start()
    {
        MineConst = 1;
        MinerUpgrade = 1;
        MinerStorage = 0;
        UpgradeCostRab = 5;
        UpgradeCostStor = 50;
        UpgradeCostUp = 5;
        n = 1;
        k = 1;
        y = 1;
        constan = 2;
        MinerMax = 200;
        ;
        
}

    // Update is called once per frame
    void Update()
    {
        if (MinerStorage <= MinerMax)
        { 
        MinerStorage =( MinerStorage + (MineConst * Time.deltaTime * Miners * MinerUpgrade));
        }
        upgradeText1.text = UpgradeCostRabstr;
        upgradeText2.text = UpgradeCostStorstr;
        upgradeText3.text = UpgradeCostUpstr;

    }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 200, 50), "Кол-во куды в шахте: " + Mathf.Round(MinerStorage));
        GUI.Box(new Rect(0, 50, 200, 100), "Кол-во апгрейды: " + MinerUpgrade);
        GUI.Box(new Rect(0, 100, 200, 150), "Кол-во майнеров: " + Miners);
    }

    public void BuyUpgrade()
    {
        if (MinerUpgrade < 30 && MinerStorage > UpgradeCostUp)
        {
            MinerUpgrade++;
            MinerStorage -= UpgradeCostUp;
            n++;
            UpgradeCostUp *=Mathf.Pow(constan,n);
            UpgradeCostUpstr = UpgradeCostUp.ToString(); 
        }
        
    }
    public void BuyStorage()
    {
        if (MinerMax < 1500 && MinerStorage >UpgradeCostStor)
        {
            MinerMax = MinerMax + 50 ;
            MinerStorage -= UpgradeCostStor;
            y++;
            UpgradeCostStor *= Mathf.Pow(constan, y);
            UpgradeCostStorstr = UpgradeCostStor.ToString();
        }




    }
    public void BuyMiner()
    {
        if (Miners < 30 && MinerStorage > UpgradeCostRab)
        {
            Miners++;
            MinerStorage -= UpgradeCostRab;
            UpgradeCostRab*= Mathf.Pow(constan, k);
            UpgradeCostRabstr = UpgradeCostRab.ToString();
        }


    }
}
