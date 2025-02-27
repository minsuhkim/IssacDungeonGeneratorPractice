using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private float cellWidth;
    private float cellHeight;

    [SerializeField]
    private Transform miniMapTransform;

    [SerializeField]
    private GameObject miniRoomPrefab;
    [SerializeField]
    private GameObject currentRoom;

    private void Start()
    {
        Invoke("CreateMinimap", 1f);
    }

    private void Update()
    {
        currentRoom.GetComponent<RectTransform>().anchoredPosition = new Vector2(RoomController.instance.curRoom.X * cellWidth, RoomController.instance.curRoom.Y * cellHeight);
    }

    public void CreateMinimap()
    {
        cellWidth = miniRoomPrefab.GetComponent<RectTransform>().rect.size.x * transform.localScale.x;
        cellHeight = miniRoomPrefab.GetComponent<RectTransform>().rect.size.y * transform.localScale.y;

        for(int i=0; i<RoomController.instance.loadedRooms.Count; i++)
        {
            Vector3 miniRoomPos = new Vector3(RoomController.instance.loadedRooms[i].X * cellWidth, RoomController.instance.loadedRooms[i].Y * cellHeight, 0);
            GameObject cell = Instantiate(miniRoomPrefab);
            cell.transform.parent = miniMapTransform;
            cell.GetComponent<RectTransform>().anchoredPosition = miniRoomPos;
        }
        currentRoom.transform.parent = miniMapTransform;
    }
}
