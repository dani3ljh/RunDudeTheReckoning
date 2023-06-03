using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string playButtonSoundName;
    [SerializeField] private string menuThemeSoundName;
    [SerializeField] private float sceneLoadDelay = 0.5f;

    [Header("Objects")]
    [SerializeField] private Button playButton;
    [SerializeField] private LoadingScreen ls;

    private AudioManager am;

    void Start()
    {
        am = GetComponent<AudioManager>();
    }

    public void OnPlayButtonPressed()
    {
        playButton.interactable = false;

        am.StopSound(menuThemeSoundName);
        
        float timeToPlaySound = am.PlaySound(playButtonSoundName);

        int newSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        ls.StartLoadScreen(newSceneIndex, timeToPlaySound + sceneLoadDelay);
    }
}
