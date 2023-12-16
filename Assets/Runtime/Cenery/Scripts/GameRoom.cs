using Cinemachine;
using UnityEngine;

public class GameRoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        if(m_Camera == null)
        {
            m_Camera = GetComponentInChildren<CinemachineVirtualCamera>();
        }
    }

    public void Initialize()
    {
        CinemachineVirtualCamera[] virtualCameras = FindObjectsOfType<CinemachineVirtualCamera>();
        foreach(CinemachineVirtualCamera @object in virtualCameras)
        {
            @object.gameObject.SetActive(false);
        }
        
        m_Camera.gameObject.SetActive(true);
    }
}
