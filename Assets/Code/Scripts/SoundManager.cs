using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipReferenceListSO AudioClipReferenceListSO;

    private float volume;
    public float Volume { get { return volume; } set { volume = value; } }

    private void Awake()
    {
        Instance = this;
        volume = 1f;
    }



    private void Start()
    {
        Player.Instance.OnInteraction += Player_OnInteraction;
    }

    private void Player_OnInteraction(object sender, Player.OnInteractionEventArgs e)
    {
        CollectibleGem collectibleGem = e.interactedObject as CollectibleGem;
        if (collectibleGem != null)
        {
            PlaySound(AudioClipReferenceListSO.gemPickup, collectibleGem.transform.position);
        }
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }

    private void PlaySound(List<AudioClip> audioClipList, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClipList[Random.Range(0, audioClipList.Count)], position, volumeMultiplier * volume);
    }

    internal void PlayFootStepsSound(Vector3 position, float volume)
    {
        PlaySound(AudioClipReferenceListSO.footstep, position, volume);
    }
}
