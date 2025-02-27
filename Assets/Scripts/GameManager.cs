using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    [SerializeField]
    private GameObject minimap;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        
    }

    public void OnTestButtonClick()
    {
        var roomToClear = RoomController.instance.loadedRooms.Single(r => r.X == 0 && r.Y == 0);
        roomToClear.OpenDoor();
    }

    private void Update()
    {
        minimap.SetActive(Input.GetKey(KeyCode.Tab));
    }
}
