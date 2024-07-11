using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gravity : MonoBehaviour
{
    public Sprite[] images = new Sprite[2];
    private Image objectImage;
    private int currentIndex = 0;

    public Player player;

    void Start()
    {
        objectImage = GetComponent<Image>();
        if (images.Length > 0)
        {
            objectImage.sprite = images[currentIndex];
        }
        Button button = FindObjectOfType<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeImage);
        }
    }

    public void ChangeImage()
    {
        if (images.Length == 0)
            return;

        player.Gravity();

        currentIndex = (currentIndex + 1) % images.Length;
        objectImage.sprite = images[currentIndex];
    }
}
