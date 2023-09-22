using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI pageText;
    [SerializeField] private Text nameText;
    [SerializeField] private Text infoText;
    [SerializeField] private Text titleText;
    [SerializeField] private Text attackText;
    [SerializeField] private Text defenseText;
    [SerializeField] private Text healthText;
    [SerializeField] private Text criticalText;
    [SerializeField] private Text myInventoryCountText;
    [SerializeField] private Text maxInventoryCountText;
    [SerializeField] private Slider expBar;
    [SerializeField] private GameObject statusButton;
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private GameObject statusWindow;
    [SerializeField] private GameObject inventoryWindow;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button backButton;
    [SerializeField] private List<GameObject> inventory;
    [SerializeField] private Sprite nullImage;

    private GameManager gameManager;
    private PlayerController player;
    private int page;


    private void Awake()
    {
        page = 1;
        gameManager = GameManager.instance;
        player = gameManager.mainPlayer.GetComponent<PlayerController>();
    }

    private void Start()
    {
        nextButton.onClick.AddListener(OnNextButton);
        backButton.onClick.AddListener(OnBackButton);
        statusButton.GetComponentInChildren<Button>().onClick.AddListener(OnstatusButton);
        inventoryButton.GetComponentInChildren<Button>().onClick.AddListener(OninventoryButton);
        closeButton.GetComponentInChildren<Button>().onClick.AddListener(CloseWindow);
        closeButton.SetActive(false);
        statusWindow.SetActive(false);
        inventoryWindow.SetActive(false);
    }

    public void LevelUIUpdate()
    {
        expText.text = $"{player.baseStat.exp}/{player.baseStat.maxExp}";
        levelText.text = $"{player.baseStat.level}";
        expBar.value = (float)player.baseStat.exp / player.baseStat.maxExp;
        infoText.text = $"코딩의 노예가 된지 {player.baseStat.level}년짜리 되는 머슴입\r\n니다. 오늘도 밤샐일만 남아서 치킨을 시킬\r\n지도 모른다는 생각에 배민을 키고 있네요.";
    }

    public void GoldUIUpdate()
    {
        goldText.text = $"{player.baseStat.gold}";
    }

    public void StatUIUpdate()
    {
        attackText.text = $"{player.baseStat.attack}";
        defenseText.text = $"{player.baseStat.defense}";
        healthText.text = $"{player.baseStat.health}/{player.baseStat.maxHealth}";
        criticalText.text = $"{player.baseStat.critical}";
    }

    public void InventoryCountUpdate()
    {
        myInventoryCountText.text = $"{player.inventory.Count}";
        maxInventoryCountText.text = "/ 117";
    }

    public void UpdateUI()
    {
        nameText.text = $"{player.baseStat.name}";
        titleText.text = $"{player.baseStat.title}";
    }

    private void ButtonsChangeActive()
    {
        if (statusButton.active)
        {
            statusButton.SetActive(false);
            inventoryButton.SetActive(false);
        }
        else
        {
            statusButton.SetActive(true);
            inventoryButton.SetActive(true);
        }
    }

    private void OnstatusButton()
    {
        statusWindow.SetActive(true);
        closeButton.SetActive(true);
        ButtonsChangeActive();
    }

    private void OninventoryButton()
    {
        inventoryWindow.SetActive(true);
        closeButton.SetActive(true);
        ButtonsChangeActive();
    }

    private void CloseWindow()
    {
        if(inventoryWindow.active)
            inventoryWindow.SetActive(false);
        else
            statusWindow.SetActive(false);

        closeButton.SetActive(false);
        ButtonsChangeActive();
    }

    public void InventoryUIUpdate()
    {
        for (int i = 0; i < 9; i++)
        {
            inventory[i].GetComponent<Image>().sprite = nullImage;
        }
        if (player.inventory.Any())
        {
            for (int i = 9 * (page - 1); i < 9 * page; i++)
            {
                if (i > player.inventory.Count-1)
                {
                    break;
                }
                if (player.inventory[i] != null)
                {
                    int j = i % 9;
                    inventory[j].GetComponent<Image>().sprite = player.inventory[i].itemImage;
                }
            }
        }
    }

    private void OnNextButton()
    {
        if (page < 13)
        {
            page++;
            PageUIUpdate();
        }
    }

    private void OnBackButton()
    {
        if(page > 1)
        {
            page--;
            PageUIUpdate();
        }
    }

    public void PageUIUpdate()
    {
        pageText.text = $"{page}/13";
        InventoryUIUpdate();
    }
}
