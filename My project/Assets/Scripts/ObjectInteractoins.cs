using UnityEngine;

public class ObjectInteractoins : MonoBehaviour
{

    public GameObject[] AnomalyObjects;
    public GameObject[] MicrochipObjects;
    public GameObject[] OrnamentsObjects;


    void Start()
    {
        AnomalyObjects = GameObject.FindGameObjectsWithTag("Anomaly");
        MicrochipObjects = GameObject.FindGameObjectsWithTag("Microchip");
        OrnamentsObjects = GameObject.FindGameObjectsWithTag("Ornaments");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnAnomalyInteraction()
    {

    }

    public void OnMicrochipInteraction()
    {

    }
    public void OnObjectInteraction()
    {

    }
}
