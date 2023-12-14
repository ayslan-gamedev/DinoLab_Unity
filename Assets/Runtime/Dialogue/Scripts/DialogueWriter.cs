using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

/// <summary>
/// Write the dialogue on screen
/// </summary>
public class DialogueWriter
{
    private const int WriteDelay = 200;
    private TextMeshProUGUI UI_text, UI_name;
    private Dialogue dialogue;
    private int currentLine, currentText;
    private GameObject buttonNext;
    private int currentLangauge = 0;

    /// <summary>
    /// Inicialize Dialogue
    /// </summary>
    /// <param name="dialogueFile"></param>
    /// <param name="UI_text"></param>
    /// <param name="UI_name"></param>
    /// <param name="button"></param>
    public void StartDialogue(Dialogue dialogueFile, TextMeshProUGUI UI_text, TextMeshProUGUI UI_name, GameObject button, Language language)
    {
        dialogue = dialogueFile;
        this.UI_text = UI_text;
        this.UI_name = UI_name;
        buttonNext = button;
        currentLangauge = language.index;

        WriteDialogue();
    }

    /// <summary>
    /// Pass to next dialogue
    /// </summary>
    /// <returns>return false if not have text to pass</returns>
    public bool WriteNextText()
    {
        buttonNext.SetActive(false);

        if (currentText + 1 < dialogue.lines[currentLine].texts.Count())
        {
            currentText++;
        }
        else if (currentLine + 1 < dialogue.lines.Count())
        {
            currentLine++;
            currentText = 0;
        }
        else return false;

        WriteDialogue();
        return true;
    }

    private void WriteDialogue()
    {
        UI_text.color = dialogue.lines[currentLine].textColor;
        UI_name.color = dialogue.lines[currentLine].textColor;

        UI_text.text = string.Empty;
        _ = Write(dialogue.lines[currentLine].texts[currentLangauge].text[currentText]);
        UI_name.text = dialogue.lines[currentLine].speaker;
    }

    private async Task Write(string text)
    {
        for (int @char = 0; @char < text.Length; @char++)
        {
            UI_text.text += text[@char];
            await Task.Delay(WriteDelay);
        }

        buttonNext.SetActive(true);
    }
}
