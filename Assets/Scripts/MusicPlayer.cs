using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip musicClip;
    int currentSceneIndex;

    private void Awake()
    {
        var mp = FindObjectsOfType<MusicPlayer>().Length;
        if(mp > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = PlayerPrefsController.GetMasterVolume();
    }
    void ChangeMusic()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 2)
        {
            Debug.LogError("Es");
            audiosource.clip = musicClip;
            audiosource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        audiosource.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMusic();
    }
}
