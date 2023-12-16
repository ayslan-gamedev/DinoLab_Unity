using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public GameObject linePrefab; // Prefab para representar as linhas.

    private Vector3 startPoint;
    private GameObject currentLine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentLine = Instantiate(linePrefab, startPoint, Quaternion.identity);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentLine.GetComponent<LineRenderer>().SetPosition(1, endPoint);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Verifique aqui se os pontos conectados são válidos e tome as ações necessárias.
        }
    }


}
