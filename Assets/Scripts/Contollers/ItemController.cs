using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] private int performance;
    private DefaultStats classification;
    private PlayerController player;
    private GameManager gameManager;
    public Sprite itemImage;


    private void Start()
    {
        if (gameObject.tag != null)
        {
            TagCheck(gameObject.tag);
        }
        gameManager = GameManager.instance;
        player = gameManager.mainPlayer.transform.GetComponent<PlayerController>();
    }

    private void TagCheck(string str)
    {
        if (Enum.IsDefined(typeof(DefaultStats), str))
        {
            classification = (DefaultStats)Enum.Parse(typeof(DefaultStats), str);
        }
    }

    private void EquipItem()
    {
        player.UpdatePlayerStat(classification, performance);
    }

    private void ReleasItem()
    {
        player.UpdatePlayerStat(classification, -performance);
    }

}
