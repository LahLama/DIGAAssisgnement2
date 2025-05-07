using UnityEngine;
using UnityEngine.UI;

public class ObjectInteractoins : MonoBehaviour
{

    public GameObject[] AnomalyObjects;
    public GameObject[] MicrochipObjects;
    public GameObject[] OrnamentsObjects;


    public PlayerStatus playerStatus;
    public int AnomalyCount;
    public int MicrochipCount;
    Button button;


    void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();

        AnomalyCount = playerStatus.AnomalyCount;
        MicrochipCount = playerStatus.AnomalyCount;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnAnomalyInteraction()
    {
        button = GetComponent<Button>();
        button.gameObject.SetActive(false);
        SoundManager.PlaySound("AnomalySelect");
        playerStatus.IncAnomalyCount();


    }

    public void OnMicrochipInteraction()
    {
        button = GetComponent<Button>();
        playerStatus.IncMicrochipCount();
        SoundManager.PlaySound("MicrochipPickUp");
        button.gameObject.SetActive(false);

    }
    public void OnObjectInteraction()
    {
        //move object up
        //spawn micro IFF max numbers hasnt been spawnwed


    }


}
