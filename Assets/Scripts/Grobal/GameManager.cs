using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform mainPlayer;

    private UIManager uiManager;
    private PlayerController player;
    private int nowGold;
    private float time;

    private void Awake()
    {
        instance = this;
        uiManager = GetComponentInChildren<UIManager>();
        player = mainPlayer.GetComponent<PlayerController>();
    }

    private void Start()
    {
        uiManager.UpdateUI();
        uiManager.LevelUIUpdate();
        uiManager.GoldUIUpdate();
        uiManager.StatUIUpdate();
        uiManager.InventoryCountUpdate();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > 1)
        {
            player.baseStat.gold += 50;
            player.baseStat.exp++;
            if (player.baseStat.exp >= player.baseStat.maxExp)
            {
                player.LevelUp();
            }
            uiManager.LevelUIUpdate();
            time = 0;
        }
        if (nowGold != player.baseStat.gold)
        {
            nowGold = player.baseStat.gold;
            uiManager.GoldUIUpdate();
        }
    }
}
