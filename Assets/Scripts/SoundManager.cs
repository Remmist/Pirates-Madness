using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();

        // Отключаем звук в начале, так как объект еще не виден
        audioSource.Stop();
    }

    void OnBecameVisible()
    {
        // Воспроизводим звук, когда объект становится видимым
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void OnBecameInvisible()
    {
        // Приостанавливаем или отключаем звук, когда объект становится невидимым
        audioSource.Stop();
    }
}
