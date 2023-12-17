using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = new Sprite[2];

    private const string Player_Tag = "Player";
    [SerializeField] private float distanceToOpenDoor = 0.0015f;

    [SerializeField] private Transform teleport;
    
    SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        render.sprite = sprites[0];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(Player_Tag))
        {
            float distance = Vector2.Distance(collision.transform.position, transform.position);
            distance = Math.Abs(distance);

            if (Input.GetKeyDown(KeyCode.Escape) || distance < render.size.y + distanceToOpenDoor)
            {
                collision.transform.position = (Vector2)teleport.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Player_Tag))
        {
            render.sprite = sprites[1];
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Player_Tag))
        {
            render.sprite = sprites[0];
        }
    }
}