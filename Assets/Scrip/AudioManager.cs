using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class ListAudioSource
{
    public GameObject Objeto;
    public AudioSource AudioSource;
    public ListAudioSource(GameObject ElObjeto, AudioSource ElAudioSource)
    {
        Objeto = ElObjeto;
        AudioSource = ElAudioSource;
    }
}
public class AudioManager : MonoBehaviour
{
    static AudioManager instance;
    [SerializeField] GameObject ElObjeto;
    List<ListAudioSource> LaListaDeAudioSource = new List<ListAudioSource>();


    [SerializeField] int cantidadApagados;
    public AudioManager Instance{ get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void iniciarMusica(AudioClip elAudio)
    {
        if (cantidadApagados > 0)
        {
            foreach (ListAudioSource objeto in LaListaDeAudioSource)
            {
                if (!objeto.AudioSource.isPlaying)
                {
                    objeto.AudioSource.clip = elAudio;
                    objeto.AudioSource.Play();
                    StartCoroutine(TerminoELAudio(objeto.AudioSource));
                    break;
                }
            }
            cantidadApagados--;
        }
        else
        {
            nuevoObjeto(elAudio);
        }
    }

    void nuevoObjeto(AudioClip elAudio)
    {
        GameObject Objeto = Instantiate(ElObjeto, transform.parent);
        ListAudioSource ElAudioSource = new ListAudioSource(Objeto, Objeto.GetComponent<AudioSource>());
        LaListaDeAudioSource.Add(ElAudioSource);
        ElAudioSource.AudioSource.clip = elAudio;
        ElAudioSource.AudioSource.Play();
        StartCoroutine(TerminoELAudio(ElAudioSource.AudioSource));
    }


    private IEnumerator TerminoELAudio(AudioSource ElAudio)
    {
        // Espera hasta que el clip de audio actual termine de reproducirse
        yield return new WaitForSeconds(ElAudio.clip.length);

        // Aquí puedes hacer lo que necesites después de que el clip de audio termine
        cantidadApagados++;
    }


}
