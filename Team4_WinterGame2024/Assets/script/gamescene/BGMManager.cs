using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioClip bgmClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
