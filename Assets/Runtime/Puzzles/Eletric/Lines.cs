using DialogueSystem;
using TMPro.EditorUtilities;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Lines : MonoBehaviour
{
    [SerializeField] LineDot[] DotsLeft;
    [SerializeField] private Transform[] DotsRigh;

    private DotsConnect[] UI_Dots;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        UI_Dots = new DotsConnect[DotsLeft.Length];

        DotsRigh = ArrayUltilits.RandomArrayOrder(DotsRigh);
        DotsLeft = ArrayUltilits.RandomArrayOrder(DotsLeft);

        for (int i = 0; i < DotsLeft.Length; i++)
        {
            UI_Dots[i].Dots = new Transform[2];

            UI_Dots[i].Dots[0] = DotsLeft[i].Dot;
            UI_Dots[i].Dots[1] = DotsRigh[i];

            for (byte a = 0; a < 2; a++)
            {
                UI_Dots[i].Dots[a].GetComponentInChildren<Image>().color = DotsLeft[i].color;
                UI_Dots[i].Dots[a].GetComponentInChildren<Dot>().Id = i;
                UI_Dots[i].Dots[a].GetComponentInChildren<Dot>().lineManager = GetComponent<Lines>();
            }

            UI_Dots[i].Line = DotsLeft[i].render;
            UI_Dots[i].Line.startColor = DotsLeft[i].color;
            UI_Dots[i].Line.endColor = DotsLeft[i].color;
        }
    }

    private bool selected = false;
    private bool ended = false;

    public void EndButton(int line)
    {
        if (line == currentLine)
        {
            UI_Dots[line].Line.SetPosition(0, (Vector2)UI_Dots[line].Dots[0].transform.position);
            UI_Dots[line].Line.SetPosition(1, (Vector2)UI_Dots[line].Dots[1].transform.position);
            ended = true;
        }
        else
        {
            UI_Dots[currentLine].Line.SetPosition(0, Vector2.zero);
            UI_Dots[currentLine].Line.SetPosition(1, Vector2.zero);
        }

        currentLine = -10;

        Debug.Log("END");
    }

    public void Button(int line)
    {
        currentLine = line;
        selected = true;

        UI_Dots[line].Line.SetPosition(0, (Vector2)UI_Dots[line].Dots[0].transform.position);
        Debug.Log("Clicked " + line);
    }

    private int currentLine = 0;

    private Vector2 MousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void LateUpdate()
    {
        if (selected == true)
        {
            ConnectLine(UI_Dots[currentLine], MousePosition());
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            selected = false;
            UI_Dots[currentLine].Line.SetPosition(0, Vector2.zero);
            UI_Dots[currentLine].Line.SetPosition(1, Vector2.zero);
        }

    }


    public void ConnectLine(DotsConnect dot)
    {
        dot.Line.positionCount = 2;
        dot.Line.SetPosition(0, (Vector2)dot.Dots[0].transform.position);
        dot.Line.SetPosition(1, (Vector2)dot.Dots[1].transform.position);
    }

    public void ConnectLine(DotsConnect dot, Vector2 b)
    {
        dot.Line.positionCount = 2;
        dot.Line.SetPosition(0, (Vector2)dot.Dots[0].transform.position);
        dot.Line.SetPosition(1, b);
    }


    [System.Serializable]
    public struct LineDot
    {
        public Transform Dot;
        public LineRenderer render;
        public Color color;
    }

    [System.Serializable]
    public struct DotsConnect
    {
        public Transform[] Dots { get; set; }

        public LineRenderer Line { get; set; }
    }
}
