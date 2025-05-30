using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField] GameObject loadingBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadAsynchrously());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsynchrously()
    {
        yield return new WaitForSeconds(0.35f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Scene to go to"));

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.transform.localScale = new Vector3(progress, loadingBar.transform.localScale.y, loadingBar.transform.localScale.z);

            yield return null;
        }
    }
}
