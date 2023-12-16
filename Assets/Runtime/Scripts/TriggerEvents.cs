using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerEvents : MonoBehaviour
{
    [SerializeField] private Tags TagToComparate;

    [SerializeField] private UnityEvent @event;

    private enum Tags { Player }

    // OnTriggerEvent is called wen a object colision enter the collision shape of this object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagToComparate.ToString()))
        {
            @event.Invoke();
        }
    }
}
