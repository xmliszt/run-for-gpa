using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    public AudioClip[] clips;

    private AudioSource source;
    private int audioIdx;
    private bool highScored;
    private bool switched;
    // Start is called before the first frame update
    void Start()
    {
        switched = false;
        highScored = false;
        audioIdx = 0;
        source = GetComponent<AudioSource>();
        source.clip = clips[audioIdx];
    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = FindObjectOfType<ScoreManager>().GetScore();
        int highScore = PlayerPrefs.GetInt("high_score", 0);
        if (switched && currentScore % 25 != 0)
        {
            switched = false;
        }
        if (currentScore % 25 == 0 && currentScore > 0 && !switched)
        {
            SwitchClip();
            switched = true;
        }
        if (currentScore >= highScore)
        {
            if (!highScored)
            {
                source.Stop();
                source.PlayOneShot(clips[2]);
                highScored = true;
            }
        }
    }

    void SwitchClip()
    {
        if (audioIdx == 0 || audioIdx == 2)
        {
            audioIdx = 1;
        } else if (audioIdx == 1)
        {
            audioIdx = 2;
        }
        PlayClip(audioIdx);
    }

    void PlayClip(int idx)
    {
        source.Stop();
        source.clip = clips[idx];
        source.Play();
    }
}
