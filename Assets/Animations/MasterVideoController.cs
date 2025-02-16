using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MasterVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Slider slider;
    bool isDone = false;

    public AudioSource yaySound;

    public Button playButton;
    public Button pauseButton;
    public Button stopButton;

    public bool IsPlaying
    {
        get
        {
            return videoPlayer.isPlaying;
        }
    }

    public bool IsLooping
    {
        get
        {
            return videoPlayer.isLooping;
        }
        set
        {
            videoPlayer.isLooping = value;
        }
    }

    public bool IsPrepared
    {
        get
        {
            return videoPlayer.isPrepared;
        }
    }

    public bool IsDonePlaying
    {
        get
        {
            return isDone;
        }
    }

    public double Time
    {
        get
        {
            return videoPlayer.time;
        }
        set
        {
            videoPlayer.time = value;
        }
    }

    public double NormalizedTime
    {
        get
        {
            return Time / Duration;
        }
        set
        {
            videoPlayer.time = value * Duration;
        }
    }

    public ulong Duration
    {
        get
        {
            return (ulong)(videoPlayer.frameCount / videoPlayer.frameRate);
        }
    }

    private void OnEnable()
    {
        videoPlayer.errorReceived += ErrorReceived;
        videoPlayer.prepareCompleted += PrepareCompleted;
        videoPlayer.loopPointReached += LoopPointReached;
        videoPlayer.frameReady += FrameReady;
        videoPlayer.seekCompleted += SeekCompleted;
        videoPlayer.started += Started;
    }

    private void OnDisable()
    {
        videoPlayer.errorReceived -= ErrorReceived;
        videoPlayer.prepareCompleted -= PrepareCompleted;
        videoPlayer.loopPointReached -= LoopPointReached;
        videoPlayer.frameReady -= FrameReady;
        videoPlayer.seekCompleted -= SeekCompleted;
        videoPlayer.started -= Started;
    }

    private void ErrorReceived(VideoPlayer source, string message)
    {
        Debug.Log("Video Player Error: " + message);
    }

    private void PrepareCompleted(VideoPlayer source)
    {
        Debug.Log("Video Player Ready");
        isDone = false;
    }

    private void LoopPointReached(VideoPlayer source)
    {
        Debug.Log("Video Player Loop Point Reached");
        isDone = true;
        yaySound.Play();
    }

    private void FrameReady(VideoPlayer source, long frameIdx)
    {
        Debug.Log("Video Player Frame Ready");
    }

    private void SeekCompleted(VideoPlayer source)
    {
        Debug.Log("Video Player Seek Completed");
       
    }

    private void Started(VideoPlayer source)
    {
        Debug.Log("Video Player Started");
    }

    private void Start()
    {
        // Initialization code if needed
    }

    private void Update()
    {
        if (!IsPrepared)
        {
            return;
        }

        slider.value = (float)NormalizedTime;

        if(IsPlaying){
            playButton.interactable = false;
            pauseButton.interactable = true;
            stopButton.interactable = true;
        } else {
            playButton.interactable = true;
            pauseButton.interactable = false;
            stopButton.interactable = false;
        }

        if (IsDonePlaying)
        {
            playButton.interactable = false;
            pauseButton.interactable = false;
            stopButton.interactable = false;
        }
    }

    public void Play()
    {
        if (!IsPrepared)
        {
            return;
        }

        videoPlayer.Play();
    }

    public void Pause()
    {
        if (!IsPrepared)
        {
            return;
        }

        videoPlayer.Pause();
    }

    public void Stop()
    {
        if (!IsPrepared)
        {
            return;
        }

        videoPlayer.Stop();
    }

    public void Restart()
    {
        if (!IsPrepared)
        {
            return;
        }

        videoPlayer.Stop();
        videoPlayer.Play();
    }

    public void Prepare()
    {
        videoPlayer.Prepare();
    }

    public void Seek(float normalizedTime)
    {
        if (!IsPrepared)
        {
            return;
        }

        normalizedTime = Mathf.Clamp(normalizedTime, 0, 1);
        videoPlayer.time = normalizedTime * Duration;
    }

    public void SetVolume(float volume)
    {
        videoPlayer.SetDirectAudioVolume(0, volume);
    }

    public void SetPlaybackSpeed(float speed)
    {
        videoPlayer.playbackSpeed = speed;
    }

    public void SetLoop(bool loop)
    {
        videoPlayer.isLooping = loop;
    }

    public void SetTime(float seconds)
    {
        videoPlayer.time = (double)seconds;
    }

    public void SetTimeNormalized(float normalizedTime)
    {
        videoPlayer.time = (double)(normalizedTime * Duration);
    }

    public void SetPlaybackRate(float rate)
    {
        videoPlayer.playbackSpeed = rate;
    }
}

