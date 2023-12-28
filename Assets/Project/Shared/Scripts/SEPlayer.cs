using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    // シングルトンパターンの実装
    public static SEPlayer Instance;
    // AudioSource
    public AudioSource audioSource;
    // 進化時の効果音
    public AudioClip evolutionSound;

    // シングルトンパターンの実装
    void Awake()
    {
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

    // SEの音量を更新する
    public void UpdateSeVolume()
    {
        // AudioSourceの音量を更新する
        audioSource.volume = EasySaveManager.Instance.SeVolume;
    }

    // 進化時の効果音を再生する
    public void PlayEvolutionSound()
    {
        audioSource.PlayOneShot(evolutionSound);
    }
}
