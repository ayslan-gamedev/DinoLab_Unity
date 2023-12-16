using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public Lines lineManager { get; set; }

    public int Id { get; set; }

    public void Clicked()
    {
        lineManager.Button(Id);
    }

    public void Up()
    {
        lineManager.EndButton(Id);
    }
}
