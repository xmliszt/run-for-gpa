using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditEnvironment : MonoBehaviour
{
    public Sprite[] backgrounds;
    public GameObject[] characters;

    public GameObject background;

    private int backgroundIdx;
    private int characterIdx;
    private GameObject player;
    private void Awake()
    {
        backgroundIdx = 0;
        characterIdx = 0;
        SetBackground();
        SetPlayer();
    }

    public void NextPlayer()
    {
        characterIdx++;
        if (characterIdx >= characters.Length)
        {
            characterIdx = 0;
        }
        SetPlayer();
    }

    public void PrevPlayer()
    {
        characterIdx--;
        if (characterIdx < 0)
        {
            characterIdx = characters.Length - 1;
        }
        SetPlayer();
    }

    public void NextBackground()
    {
        backgroundIdx++;
        if (backgroundIdx >= backgrounds.Length)
        {
            backgroundIdx = 0;
        }
        SetBackground();
    }

    public void PrevBackground()
    {
        backgroundIdx--;
        if (backgroundIdx < 0)
        {
            backgroundIdx = backgrounds.Length - 1;
        }
        SetBackground();
    }

    public void SetBackground()
    {
        background.GetComponent<SpriteRenderer>().sprite = backgrounds[backgroundIdx];
    }

    public void SetPlayer()
    {
        if (player != null)
        {
            Destroy(player);
        }
        player = Instantiate(characters[characterIdx], Vector3.zero, Quaternion.Euler(0,90,0));
        player.GetComponent<PlayerController>().dirt.Play();
    }
}
