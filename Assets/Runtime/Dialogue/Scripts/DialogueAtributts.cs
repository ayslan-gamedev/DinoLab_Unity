using UnityEngine;

namespace DialogueSystem 
{
    [System.Serializable]
    public struct DialogueLine
    {
        public string speaker;
        public Line[] texts;
        public Color textColor;
        public Sprite speakerProtait;
    }

    [System.Serializable]
    public struct Line
    {
        [TextArea(5,10)]public string[] text;
        public Language langauge;
    }
}