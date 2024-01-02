using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipReferenceListSO", menuName = "ScriptableObject/AudioClipReferenceListSO")]

public class AudioClipReferenceListSO : ScriptableObject
{
    public List<AudioClip> footstep;
    public List<AudioClip> gemPickup;
    public List<AudioClip> switchToggle;
}
