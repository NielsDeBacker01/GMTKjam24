using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxED;
    [SerializeField] AudioSource sfxPD;
    [SerializeField] AudioSource sfxE;
    [SerializeField] AudioSource OST1;
    [SerializeField] AudioSource OST2;
    [SerializeField] AudioSource OST3;
    [SerializeField] AudioSource OST4;
    [SerializeField] AudioValues volume;

    public void playEnemyDeathSound()
    {
        sfxED.volume = volume.sfx;
        sfxED.Play();
    }

    public void playPlayerDeathSound()
    {
        sfxPD.volume = volume.sfx;
        sfxPD.Play();
    }

    public void playExplodeSound()
    {
        sfxE.volume = volume.sfx;
        sfxE.Play();
    }

    public void Start()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Stage0TitleScreen":
                OST1.volume = volume.music;
                OST1.Play();
                break;
            case "Stage1City":
                OST2.volume = volume.music;
                OST2.Play();
                break;
            case "Stage2World":
                OST3.volume = volume.music;
                OST3.Play();
                break;       
            case "Stage3Space":
                OST4.volume = volume.music;
                OST4.Play();
                break;
        }
    }

    public void Update()
    {
        OST1.volume = volume.music;
        OST2.volume = volume.music;
        OST3.volume = volume.music;
        OST4.volume = volume.music;
    }
}