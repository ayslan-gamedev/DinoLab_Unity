using UnityEngine;

public class DinoManager : MonoBehaviour
{
    [SerializeField] private Room[] Rooms;

    [SerializeField] private GameObject dino;

    public int CurrenDinoRoom { get; private set; }

    private int _roomWithAudio;

    public int RoomWithAudio
    {
        get => _roomWithAudio;
        set
        {
            timer = 0;

            if(value > RoomLenght - 1)
            {
                value = 0;
            }
            if (value < 0)
            {
                value = RoomLenght - 1;
            }

            CurrenDinoRoom = value;
            AtualizeDinoPosition();

            _roomWithAudio = value;
        }
    }

    public int RoomLenght { get; private set; }

    private Transform playerTransform;

    [SerializeField] private float timeToMoveDino;
    private float timer;

    void Start()
    {
        RoomLenght = Rooms.Length;
        CurrenDinoRoom = Random.Range(0, RoomLenght);
        ChangeRoom();

        playerTransform = FindAnyObjectByType<Player>().GetComponent<Transform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToMoveDino)
        {
            ChangeRoom();
            timer = 0;
        }

        dino.transform.rotation = DinoRotation();
    }

    private Quaternion DinoRotation()
    {
        Vector2 direction = playerTransform.position - dino.transform.position;
        return Quaternion.AngleAxis(Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg, Vector3.forward);
    }

    private void ChangeRoom()
    {
        CurrenDinoRoom = Random.Range(0, 2) == 0 ? CurrenDinoRoom - 1 : CurrenDinoRoom + 1;
        CurrenDinoRoom = CurrenDinoRoom < 0 ? RoomLenght - 1 : CurrenDinoRoom > RoomLenght ? 0 : CurrenDinoRoom;

        AtualizeDinoPosition();
    }

    private void AtualizeDinoPosition()
    {
        Vector3 position = Rooms[CurrenDinoRoom].dinoSpawn[Random.Range(0, Rooms[CurrenDinoRoom].dinoSpawn.Length - 1)].transform.position;
        dino.transform.position = position;
    }
}

[System.Serializable]
public struct Room
{
    public Transform[] dinoSpawn;
}
