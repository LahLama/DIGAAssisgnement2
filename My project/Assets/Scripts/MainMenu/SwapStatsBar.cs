using UnityEngine;

public class SwapStatsBar : MonoBehaviour
{
    public GameObject statsBar;
    public GameObject ObjectiveBar;


    public void SwapBar()
    {
        statsBar.SetActive(false);
        ObjectiveBar.SetActive(false);
        //blackBars.SetActive(true);
    }
}
