using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tablet : MonoBehaviour
{
    [SerializeField] private Image tabletImage;
    [SerializeField] private Sprite[] tabletSprites;

    private const int playAudioPrice = 20;

    [SerializeField] int DelayTime;

    [SerializeField] private Image[] RoomsImages;
    [SerializeField] private Sprite scan, atention, playingAudio;

    [SerializeField] private Image WarmingImage;

    [SerializeField] private double batteryDecress;
    private float timerBattery;

    private double _battery = 50;

    public double Battery
    {
        get => _battery;
        set
        {
            _battery = value;
            AtualizeBattery();
        }
    }

    [SerializeField] private TextMeshProUGUI batteryLevel;

    private Tools currentSelectedTool;

    [SerializeField] public enum Tools { Scaner, PlayAudio }

    private int currentRoomUsed;

    DinoManager m_manager;

    private void Start()
    {
        m_manager = FindAnyObjectByType<DinoManager>();
        AtualizeBattery();
    }

    private void Update()
    {
        timerBattery += Time.deltaTime;
        if(timerBattery >= batteryDecress)
        {
            AtualizeBattery();
            timerBattery = 0;
        }
    }

    private void AtualizeBattery()
    {
        if(batteryLevel != null)
        {
            batteryLevel.text = _battery + "%";
        }
     
        if (Compare(_battery, 80, 100))
        {
            tabletImage.sprite = tabletSprites[0];
        }
        else if (Compare(_battery, 60, 80))
        {
            tabletImage.sprite = tabletSprites[1];
        }
        else if (Compare(_battery, 30, 60))
        {
            tabletImage.sprite = tabletSprites[2];
        }
        else if (Compare(_battery, 0, 30))
        {
            tabletImage.sprite = tabletSprites[3];
        }

        static bool Compare(double value, double min, double max)
        {
            return value > min && value <= max;
        }
    }

    public void SelectTool(int toolSelected)
    {
        currentSelectedTool = (Tools)toolSelected;
    }

    public void SelectRoom(int room)
    {
        DesactiveAll();

        if (currentRoomUsed == room)
        {
            return;
        }
        currentRoomUsed = room;

        switch (currentSelectedTool)
        {
            case Tools.Scaner:
                RoomsImages[room].gameObject.SetActive(true);
                RoomsImages[room].sprite = scan;
                ScanRoom(room);
                break;

            case Tools.PlayAudio:
                m_manager.RoomWithAudio = room;
                _battery -= playAudioPrice;
                RoomsImages[room].gameObject.SetActive(true);
                RoomsImages[room].sprite = playingAudio;
                break;
        }
    }

    private void ScanRoom(int room)
    {
        if (CompareRoom(room))
        {
            AlertRoom(room);
        }
        else
        {
            int i = 0;
            int possibleRoom = room + 1 >= m_manager.RoomLenght ? 0 : room + 1;

            do
            {
                if (CompareRoom(possibleRoom))
                {
                    AlertRoom(possibleRoom);
                }

                possibleRoom = room - 1 < 0 ? m_manager.RoomLenght - 1 : room - 1;
                i++;
            } while (i < 2);
        }

        void AlertRoom(int roomToActive)
        {
            RoomsImages[roomToActive].gameObject.SetActive(true);
            RoomsImages[roomToActive].sprite = atention;

            WarmingImage.gameObject.SetActive(true);
        }
    }

    private bool CompareRoom(int roomToComparet)
    {
        return roomToComparet == m_manager.CurrenDinoRoom;
    }

    public void DesactiveAll()
    {
        foreach (Image img in RoomsImages)
        {
            img.gameObject.SetActive(false);
        }

        WarmingImage.gameObject.SetActive(false);
        currentRoomUsed = 90;
    }
}