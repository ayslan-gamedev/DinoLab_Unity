using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAtributts playerAtributts;
    public PlayerAtributts PlayerAtributts { get { return playerAtributts; } }

    private const string Axis_Horizontal = "Horizontal";
    private const string Axis_Vertical = "Vertical";

    private Cinemachine.CinemachineVirtualCamera virtualCamera;

    [SerializeField] private Transform MouseObject;

    [SerializeField][Range(0, 0.006f)] private float lerpTime = 0.002f;

    private Rect screenRect = Rect.zero;

    private const string Anim_Idle = "Idle";
    private const string Player_Blendtree = "Player";

    Rigidbody2D rigidiBody;

    public byte PlayerSelected { get; private set; }

    SpriteRenderer render;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidiBody = GetComponent<Rigidbody2D>();

        virtualCamera = FindAnyObjectByType<Cinemachine.CinemachineVirtualCamera>();
        screenRect = new Rect(0f, 0f, Screen.width, Screen.height);

        GameManager manager = FindAnyObjectByType<GameManager>();

        if (manager != null)
        {
            PlayerSelected = manager.CharacterSelected;
        }

        animator = GetComponentInChildren<Animator>();
        animator.SetFloat(Player_Blendtree, PlayerSelected);

        render = GetComponentInChildren<SpriteRenderer>();
    }

    public Vector2 Direction()
    {
        return new(Input.GetAxisRaw(Axis_Horizontal), Input.GetAxisRaw(Axis_Vertical));
    }

    // Update is called once per frame
    void Update()
    {
        rigidiBody.velocity = Direction() * playerAtributts.velocity;
        animator.SetBool(Anim_Idle, Direction() == Vector2.zero);

        if (Direction().x != 0)
        {
            render.flipX = Direction().x < 0;
        }

        if (MouseObject == null)
        {
            return;
        }

        if (virtualCamera == null)
        {
            virtualCamera = FindAnyObjectByType<Cinemachine.CinemachineVirtualCamera>();
            return;
        }

        if (virtualCamera.Follow != transform)
        {
            if (screenRect.Contains(Input.mousePosition))
            {
                Vector2 relativeMousePosition = transform.position + (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f));
                MouseObject.position = Vector2.Lerp(transform.position, relativeMousePosition, lerpTime);
            }
        }

        if (Direction() != Vector2.zero && virtualCamera.Follow != transform)
        {
            virtualCamera.Follow = transform;
            MouseObject.transform.position = transform.position;
        }
        else if (virtualCamera.Follow == transform)
        {
            virtualCamera.Follow = MouseObject;
        }
    }
}
