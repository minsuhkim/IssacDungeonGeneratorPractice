using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    [SerializeField]
    private GameObject minimap;

    private bool isPause = false;

    public Image[] heartUI;
    // 0이 빨간색, 1이 흰색
    public Sprite[] heartImages;

    public Item[] itemList;
    public GameObject itemPanel;

    public GameObject overPanel;
    public GameObject clearPanel;
    public GameObject optionPanel;

    public GameObject bossHPSlider;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Debug.Log(RoomController.instance.loadedRooms.Count);
    }

    public void OnItemButtonClick(int index)
    {
        RoomController.instance.loadedRooms.Single(r => r.X == 0 && r.Y == 0).OpenDoor();

        player.attack = itemList[index].attack;
        player.attackRate = 1/(float)itemList[index].rate;
        player.attackType = itemList[index].attackType;

        itemPanel.SetActive(false);
    }

    public void OnRetryButtonClick()
    {
        //Time.timeScale = 1;
        RoomController.instance.loadedRooms.Clear();
        RoomController.instance.loadRoomQueue.Clear();
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // 어플리케이션 종료
        #endif
    }

    private void Update()
    {
        minimap.SetActive(Input.GetKey(KeyCode.Tab));

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void HpUIUpdate()
    {
        for(int i = 0; i<player.hp; i++)
        {
            heartUI[i].sprite = heartImages[0];
        }

        for(int i=player.hp; i<3; i++)
        {
            heartUI[i].sprite = heartImages[1];
        }
    }

    public void GameClear()
    {
        clearPanel.SetActive(true);
    }

    public void GameOver()
    {
        overPanel.SetActive(true);
    }

    public void SetBossHPSlider()
    {
        bossHPSlider.SetActive(true);
    }

    public void Pause()
    {
        isPause = true;
        optionPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPause = false;
        optionPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
