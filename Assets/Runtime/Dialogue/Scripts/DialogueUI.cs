using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour 
{ 
    [SerializeField] private GameObject DialogueUIObject;

    [SerializeField] private TextMeshProUGUI UI_text, UI_name;
    [SerializeField] private GameObject buttonNext;

    DialogueWriter writer;

    public void InitializeDialogue(Dialogue dialogueFile)
    {
        writer = new();
        writer.StartDialogue(dialogueFile, UI_text, UI_name, buttonNext, new());
    }

    public void NextButton() 
    {
        DialogueUIObject.SetActive(writer.WriteNextText());
    }
}
