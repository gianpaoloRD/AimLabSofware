using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public void PlaySoundEffect()
    {
        AudioManager.instance.PlaySfx("Click");
        AudioManager.instance.PlaySfx("Null");
    }
}
