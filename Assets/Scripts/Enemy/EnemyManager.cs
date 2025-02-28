using UnityEngine;

//public enum EnemyType
//{

//}

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Room room;

    public void SpawnEnemy()
    {
        if(room.X == 0 && room.Y == 0)
        {
            room.enemyCount = 0;
            room.OpenDoor();
        }
        else if (room.name.Contains("End"))
        {
            Vector2 roomLocation = new Vector2(room.X * room.Width, room.Y * room.Height);
            Vector2 spawnPosition = new Vector2(roomLocation.x, roomLocation.y);
            room.enemyCount = 1;
            GameObject clone = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            clone.GetComponent<Boss>().room = room;
        }
        else
        {
            Vector2 roomLocation = new Vector2(room.X * room.Width, room.Y * room.Height);
            Vector2 spawnPosition = new Vector2(roomLocation.x + Random.Range(-8f, 8f), roomLocation.y + Random.Range(-3.5f, 3.5f));
            GameObject clone = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            clone.GetComponent<Enemy>().room = room;
        }
    }
}
