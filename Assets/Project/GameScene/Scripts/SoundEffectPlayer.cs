using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    // AudioSource
    public AudioSource audioSource;
    // 進化時の効果音
    public AudioClip evolutionSound;

    // 進化時の効果音を再生する
    public void PlayEvolutionSound()
    {
        audioSource.PlayOneShot(evolutionSound);
    }
}
