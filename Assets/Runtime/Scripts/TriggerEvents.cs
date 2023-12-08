using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerEvents : MonoBehaviour
{
    [SerializeField] private Tags TagToComparate;
    [SerializeField] private PreSetedEvents eventType;

    [SerializeField] private UnityEvent @event;

    PolygonCollider2D collisionShape;
    Cinemachine.CinemachineConfiner2D confider;

    // Start is called before the first frame update
    private void Start()
    {
        confider = FindAnyObjectByType<Cinemachine.CinemachineConfiner2D>();
        collisionShape = gameObject.GetComponent<PolygonCollider2D>();
    }

    private enum Tags { Player }

    private enum PreSetedEvents { Evreything, None, ChangeCameraShape }

    // OnTriggerEvent is called wen a object colision enter the collision shape of this object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagToComparate.ToString()))
        {
            switch (eventType) 
            {
                case PreSetedEvents.Evreything:
                    @event.Invoke();
                    confider.m_BoundingShape2D = collisionShape;
                    break;

                case PreSetedEvents.None:
                    @event.Invoke();
                    break;
                
                case PreSetedEvents.ChangeCameraShape:
                    confider.m_BoundingShape2D = collisionShape;
                    break;
            }
        }
    }
}
