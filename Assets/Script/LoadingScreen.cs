using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private List<GameObject> loadingScreenObjects;

    void Start()
    {
        GameObjectSetActive(loadingScreenObjects, false);
    }

    public void StartLoadScreen(int index, float delay = 0f)
    {
        GameObjectSetActive(loadingScreenObjects, true);

        StartCoroutine(LoadSceneAfterDelay(index, delay));
    }

    IEnumerator LoadSceneAfterDelay(int index, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(index);
    }

    private void GameObjectSetActive(List<GameObject> objects, bool isActive)
    {
        foreach (var obj in objects)
            obj.SetActive(isActive);
    }
}
