using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string soundName;
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

        float timeToPlaySound = am.PlaySound(soundName);

        int newSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        ls.StartLoadScreen(newSceneIndex, timeToPlaySound);
    }
}
