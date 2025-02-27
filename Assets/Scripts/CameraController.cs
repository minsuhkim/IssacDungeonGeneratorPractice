using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Room curRoom;
    public float moveSpeedWhenRoomChange;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if(curRoom == null)
        {
            return;
        }

        Vector3 targetPos = GetCameraTargetPosition();
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeedWhenRoomChange);
    }

    Vector3 GetCameraTargetPosition()
    {
        if(curRoom == null)
        {
            return Vector3.zero;
        }

        Vector3 targetPos = curRoom.GetRoomCenter();
        targetPos.z = transform.position.z;

        return targetPos;
    }

    public bool IsSwitchingScene()
    {
        return transform.position.Equals(GetCameraTargetPosition()) == false;
    }
}
