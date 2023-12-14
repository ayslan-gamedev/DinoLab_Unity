using TMPro.EditorUtilities;
using UnityEngine;


public class DinoManager : MonoBehaviour
{
    [SerializeField] private Room[] Rooms;

    [SerializeField] private GameObject dino;

    [SerializeField] private int currenRoom = 0;
    private int roomLenght = 7;

    public int RoomWithAudio { get; set; }

    [SerializeField] private float timeToMoveDino;
    private float timer;

    void Start()
    {
        roomLenght = Rooms.Length;
        currenRoom = Random.Range(0, roomLenght);
        ChangeRoom();
    }

    private void Update()
    {   
        timer += Time.deltaTime;

        if (timer >= timeToMoveDino)
        {
            ChangeRoom();
            timer = 0;
        }
    }

    private void ChangeRoom()
    {
        currenRoom = Random.Range(0, 2) == 0 ? currenRoom - 1 : currenRoom + 1;
        currenRoom = currenRoom < 0 ? roomLenght : currenRoom > roomLenght ? 0 : currenRoom;

        if (RoomWithAudio != 0 && RoomWithAudio < roomLenght + 1)
        {
            currenRoom = RoomWithAudio + 1;
            RoomWithAudio = 0;
        }

        dino.transform.position = Rooms[currenRoom].dinoSpawn[Random.Range(0, Rooms[currenRoom].dinoSpawn.Length - 1)].transform.position;
    }
}

[System.Serializable]
public struct Room
{
    public Transform[] dinoSpawn;
}
