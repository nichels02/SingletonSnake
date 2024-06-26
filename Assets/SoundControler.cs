using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : singletonGenericoPersistente<SoundControler>
{
    AudioSource ElAudioSource;
    [SerializeField] AudioClip[] Musica = new AudioClip[5];



    void Start()
    {
        ElAudioSource = GetComponent<AudioSource>();
        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        // Espera hasta que termine el clip
        

        int random = UnityEngine.Random.Range(0, Musica.Length);
        ElAudioSource.clip = Musica[random];
        ElAudioSource.Play();

        yield return new WaitForSeconds(ElAudioSource.clip.length);
    }
    public void CambiarMusica(AudioClip ElAudio)
    {
        ElAudioSource.clip = ElAudio;
        ElAudioSource.Play();
    }

    

}
