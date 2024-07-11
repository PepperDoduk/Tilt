using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Sprite[] images = new Sprite[2];
    private Image objectImage;
    private int currentIndex = 0;

    public Player player;

    void Start()
    {
        Button button = FindObjectOfType<Button>();
        if (button != null)
        {
            SceneManager.LoadScene("Ingame");
        }
    }

}
