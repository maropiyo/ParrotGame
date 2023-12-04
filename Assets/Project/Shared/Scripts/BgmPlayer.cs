using UnityEngine;

public class BgmPlayer : MonoBehaviour
{
    // シングルトンパターンの実装
    public static BgmPlayer Instance;

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
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // BGMを再生する。
        PlayBGM();
    }

    // BGMを再生する。
    void PlayBGM()
    {
        // AudioSourceにBGMを設定して再生
        bgmAudioSource.clip = bgm;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    // BGMを停止する。
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
}
