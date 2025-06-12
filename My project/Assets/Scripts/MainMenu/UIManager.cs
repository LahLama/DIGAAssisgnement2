using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void onPlayButtonClicked()
    {
        PlayerPrefs.SetString("Scene to go to", "True James Room");
        //SceneManager.LoadScene("LoadingScene");
    }
}
