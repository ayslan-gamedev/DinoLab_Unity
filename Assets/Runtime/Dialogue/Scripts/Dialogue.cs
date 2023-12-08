using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;

[CreateAssetMenu(fileName = "Dialogue Object", menuName = "Dialogue/Dialogue Object")]
public class Dialogue : ScriptableObject
{
    public List<DialogueLine> lines;
}