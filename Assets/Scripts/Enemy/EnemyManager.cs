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
        Vector2 spawnPosition = new Vector2(room.X * room.Width, room.Y * room.Height);
        GameObject clone = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        clone.GetComponent<Enemy>().room = room;
    }
}
