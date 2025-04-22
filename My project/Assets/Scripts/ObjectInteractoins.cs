using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteractoins : MonoBehaviour
{

    public GameObject[] AnomalyObjects;
    public GameObject[] MicrochipObjects;
    public GameObject[] OrnamentsObjects;


    public PlayerStatus playerStatus;
    public int AnomalyCount;


    void Start()
    {
        AnomalyObjects = GameObject.FindGameObjectsWithTag("Anomaly");
        MicrochipObjects = GameObject.FindGameObjectsWithTag("Microchip");
        OrnamentsObjects = GameObject.FindGameObjectsWithTag("Ornaments");

        playerStatus = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();

        AnomalyCount = playerStatus.AnomalyCount;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnAnomalyInteraction()
    {

        this.gameObject.SetActive(false);
        AnomalyCount++;
        print("ANOMALY COUNT IS: " + AnomalyCount);

    }

    public void OnMicrochipInteraction()
    {

    }
    public void OnObjectInteraction()
    {

    }


}
