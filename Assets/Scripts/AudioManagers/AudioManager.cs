using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sonidos[] sonidos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        foreach (Sonidos s in sonidos)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.loop = s.loop;
            s.audioSource.volume = s.volumen;
        }
    }

    public void Play(string nombre)
    {
        foreach (Sonidos s in sonidos)
        {
            if (s.nombreAudio == nombre)
            {
                s.audioSource.Play();
                return;
            }
        }
    }

    public void Stop(string nombre)
    {
        foreach (Sonidos s in sonidos)
        {
            if (s.nombreAudio == nombre)
            {
                s.audioSource.Stop();
                return;
            }
        }
    }
}
