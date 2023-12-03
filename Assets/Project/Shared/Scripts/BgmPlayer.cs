using UnityEngine;

public class BgmPlayer : MonoBehaviour
{
    public static BgmPlayer Instance;
    public bool DontDestroyEnabled = true;

    // AudioSourceコンポーネント
    public AudioSource bgmAudioSource;
    // BGM
    public AudioClip bgm;

    void Awake()
    {
        // シングルトンパターンの実装
        if (Instance == null)
        {
            Instance = this;

            if (DontDestroyEnabled)
            {
                // Sceneを遷移してもオブジェクトが消えないようにする
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBGM();
    }

    void PlayBGM()
    {
        // AudioSourceにBGMを設定して再生
        bgmAudioSource.clip = bgm;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
}
