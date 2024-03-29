using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> aladin;
    public List<AudioClip> fart;
    public List<AudioClip> sax;
    public List<AudioClip> dirty;
    public List<AudioClip> gameOver;
    int contaAladin = 0;
    int contaSax = 0;
    int contaDirty = 0;
    int contaFart = 0;
    int contaGameOver = 0;
    public void PlayAladin()
    {
        audioSource.clip = aladin[contaAladin];
        audioSource.Play();
        contaAladin++;
        if (contaAladin > aladin.Count - 1) contaAladin = 0;
       
    }

    public void PlayFart()
    {
        audioSource.clip = fart[contaFart];
        audioSource.Play();
        contaFart++;
        if (contaFart > fart.Count - 1) contaFart = 0;
    }
    public void PlaySax()
    {
        audioSource.clip = sax[contaSax];
        audioSource.Play();
        contaSax++;
        if (contaSax > sax.Count - 1) contaSax = 0;
    }

    public void PlayDirty()
    {
        audioSource.clip = dirty[contaDirty];
        audioSource.Play();
        contaDirty++;
        if (contaDirty > dirty.Count - 1) contaDirty = 0;
    }

    public void StopSound()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }

    public void PlayGameOver()
    {
        audioSource.clip = gameOver[contaGameOver];
        audioSource.Play();
        contaGameOver++;
        if (contaGameOver > gameOver.Count - 1) contaGameOver = 0;
    }

}
