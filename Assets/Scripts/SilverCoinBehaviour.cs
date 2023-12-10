using System;
using UnityEngine;

public class SilverCoinBehaviour : CollectibleItem
{
    [SerializeField] private GameObject effect;
    [SerializeField] private AudioSource _audioCoin;

    protected override void CollectBehaviour()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        inventory.SilverCoins++;
        Destroy(gameObject);

        // Включить AudioSource перед воспроизведением звука
        _audioCoin.enabled = true;

        // Воспроизвести звук однократно
        StartCoroutine(PlayAndDisableAudio(_audioCoin.clip));

        Instantiate(effect, transform.position, Quaternion.identity);
    }

    private System.Collections.IEnumerator PlayAndDisableAudio(AudioClip clip)
    {
        // Воспроизвести звук
        _audioCoin.PlayOneShot(clip);

        // Ждать, пока звук полностью воспроизойдется
        yield return new WaitForSeconds(clip.length);

        // Отключить AudioSource после воспроизведения
        _audioCoin.enabled = false;
    }

    public override void UseItem()
    {
        throw new NotImplementedException();
    }
}
