using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private bool videoHasBeenPlayed;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    private void Update()
    {
    }
    public void PlayVideoWithThisFunc()
    {
        if (!videoPlayer.isPlaying && !videoHasBeenPlayed)
        {
            videoPlayer.Play();
            videoHasBeenPlayed = true;
            videoPlayer.loopPointReached += NextScene;
        }
    }
    private void NextScene(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(2);
    }
    public void Onclick()
    {
        PlayVideoWithThisFunc();
    }
}
