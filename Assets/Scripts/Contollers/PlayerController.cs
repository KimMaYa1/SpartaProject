using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public CharacterStat baseStat;
    UIManager uIManager;
    public List<ItemController> itemControllers = new List<ItemController>(117);

    private void Awake()
    {
        baseStat.title = "코딩노예";
        baseStat.name = "조범준";
        baseStat.gold = 500;
        baseStat.attack = 20;
        baseStat.defense = 10;
        baseStat.health = 80;
        baseStat.critical = 25;
        baseStat.maxHealth = 80;
        baseStat.level = 1;
        baseStat.exp = 0;
        baseStat.maxExp = 12;
    }

    private void Start()
    {
        uIManager = UIManager.instance;
    }

    public void LevelUp()
    {
        baseStat.level++;
        baseStat.exp = 0;
    }

    public void UpdatePlayerStat(DefaultStats stat, int performance)
    {
        switch (stat)
        {
            case DefaultStats.Attack :
                baseStat.attack += performance;
                break;
            case DefaultStats.Defense :
                baseStat.defense += performance;
                break;
            case DefaultStats.Health :
                baseStat.maxHealth += performance;
                baseStat.health += performance;
                break;
            case DefaultStats.Critical :
                baseStat.critical += performance;
                break;
            default:
                break;
        }

        uIManager.StatUIUpdate();
    }
}
