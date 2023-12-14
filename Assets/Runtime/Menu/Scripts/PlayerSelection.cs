using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private Texture2D[] textures = new Texture2D[2];
    [SerializeField] private RawImage[] images = new RawImage[2];

    private byte[] currentTexture = new byte[2];

    public void ChangeCharacter()
    {

        for(int i = 0; i < textures.Length; i++)
        {
            currentTexture[i] = (byte)(currentTexture[i] == 0 ? 1 : 0);
            images[i].texture = textures[currentTexture[i]];
        }
    }

}
