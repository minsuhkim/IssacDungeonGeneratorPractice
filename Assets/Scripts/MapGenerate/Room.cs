using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Random = UnityEngine.Random;


public class Room : MonoBehaviour
{
    public int Width;
    public int Height;
    public int X;
    public int Y;

    public Door leftDoor;
    public Door rightDoor;
    public Door topDoor;
    public Door bottomDoor;

    [Header("Enemy")]
    public bool isClear = false;
    public int enemyCount;
    [SerializeField]
    private GameObject doorCollider;

    public EnemyManager enemySpawner;

    private bool updatedDoors = false;

    public List<Door> doors = new List<Door>();

    public Room(int x, int y)
    {
        X = x;
        Y = y;
    }

    private void Start()
    {
        if (RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene!");
            return;
        }

        Door[] ds = GetComponentsInChildren<Door>();
        foreach(Door d in ds)
        {
            doors.Add(d);
            switch (d.doorType)
            {
                case Door.DoorType.right:
                    rightDoor = d;
                    break;
                case Door.DoorType.left:
                    leftDoor = d;
                    break;
                case Door.DoorType.top:
                    topDoor = d;
                    break;
                case Door.DoorType.bottom:
                    bottomDoor = d;
                    break;
            }
        }

        RoomController.instance.RegisterRoom(this);

        enemyCount = Random.Range(4, 9);
    }

    private void Update()
    {
        if(name.Contains("End") && !updatedDoors)
        {
            RemoveUnconnectedDoors();
            updatedDoors = true;
        }
    }

    public void OpenDoor()
    {
        isClear = true;
        // 현재 방 오픈
        doorCollider.SetActive(false);

        // 주변 방 문 오픈
        if (RoomController.instance.loadedRooms.Find(r => r.X == X + 1 && r.Y == Y))
        {
            RoomController.instance.loadedRooms.Single(r => r.X == X + 1 && r.Y == Y).doorCollider.SetActive(false);
        }
        if (RoomController.instance.loadedRooms.Find(r => r.X == X - 1 && r.Y == Y))
        {
            RoomController.instance.loadedRooms.Single(r => r.X == X - 1 && r.Y == Y).doorCollider.SetActive(false);
        }
        if (RoomController.instance.loadedRooms.Find(r => r.X == X && r.Y == Y + 1))
        {
            RoomController.instance.loadedRooms.Single(r => r.X == X && r.Y == Y + 1).doorCollider.SetActive(false);
        }
        if (RoomController.instance.loadedRooms.Find(r => r.X == X && r.Y == Y - 1))
        {
            RoomController.instance.loadedRooms.Single(r => r.X == X && r.Y == Y - 1).doorCollider.SetActive(false);
        }
    }

    public void RemoveUnconnectedDoors()
    {
        foreach(Door door in doors)
        {
            switch (door.doorType)
            {
                case Door.DoorType.right:
                    if(GetRight() == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
                case Door.DoorType.left:
                    if (GetLeft() == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
                case Door.DoorType.top:
                    if (GetTop() == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
                case Door.DoorType.bottom:
                    if (GetBottom() == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }

    public Room GetRight()
    {
        if (RoomController.instance.DoesRoomExist(X + 1, Y))
        {
            return RoomController.instance.FindRoom(X + 1, Y);
        }

        return null;
    }

    public Room GetLeft()
    {
        if (RoomController.instance.DoesRoomExist(X - 1, Y))
        {
            return RoomController.instance.FindRoom(X - 1, Y);
        }

        return null;
    }
    public Room GetTop()
    {
        if (RoomController.instance.DoesRoomExist(X, Y + 1))
        {
            return RoomController.instance.FindRoom(X, Y + 1);
        }

        return null;
    }
    public Room GetBottom()
    {
        if (RoomController.instance.DoesRoomExist(X, Y - 1))
        {
            return RoomController.instance.FindRoom(X, Y - 1);
        }

        return null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }

    public Vector3 GetRoomCenter()
    {
        return new Vector3(X * Width, Y * Height);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            RoomController.instance.OnPlayerEnterRoom(this);
            Debug.Log($"플레이어 입장 {X}, {Y}");

            if (isClear == false)
            {
                Invoke("StartRoomStage", 0.2f);
                
            }
        }
    }

    private void StartRoomStage()
    {
        doorCollider.SetActive(true);
        for (int i = 0; i < enemyCount; i++)
        {
            enemySpawner.SpawnEnemy();
        }
    }
}
