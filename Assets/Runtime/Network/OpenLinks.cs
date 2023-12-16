namespace CatCity
{
    using UnityEngine;

    [AddComponentMenu("Cat City/Network")]
    public class OpenLinks : MonoBehaviour
    {
        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }
    }
}