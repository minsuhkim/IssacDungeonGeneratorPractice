using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
}
