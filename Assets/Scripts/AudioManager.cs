using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public AudioClip bgm;
    public AudioClip jumpSound;
    public AudioClip checkpointSound;
    public AudioClip endTrialSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bgmSource.clip = bgm;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlayJump() => sfxSource.PlayOneShot(jumpSound);
    public void PlayCheckpoint() => sfxSource.PlayOneShot(checkpointSound);
    public void PlayEndTrial() => sfxSource.PlayOneShot(endTrialSound);
}
