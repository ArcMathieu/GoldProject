using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static MainCamera Instance
    {
        get;
        private set;
    }

    private Vector2 camPos;
    public Room currentRoom;

    [SerializeField] private CinemachineConfiner confiner;
    [SerializeField] private CinemachineConfiner confinerGhost;

    private void Awake()
    {
        Instance = this;
    }

    public void RoomEnter(Room room)
    {
        Vector3 roomPos = room.gameObject.transform.position;
        transform.position = new Vector3(roomPos.x, roomPos.y, transform.position.z);
        currentRoom = room;

        confiner.m_BoundingShape2D = currentRoom.GetComponent<PolygonCollider2D>();
        confinerGhost.m_BoundingShape2D = currentRoom.GetComponent<PolygonCollider2D>();
    }
}
