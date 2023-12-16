using UnityEngine;

public class GameManager : MonoBehaviour
{
    private byte m_characterSelected;

    public byte CharacterSelected
    {
        get => m_characterSelected;
        set
        {
            m_characterSelected = value;
            LoadScene(1);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void LoadScene(int scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}