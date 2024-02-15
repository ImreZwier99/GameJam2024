using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnemyScript : MonoBehaviour
{
    public GameObject WaveSpawner;
    public GameObject UI;

    public void Button()
    {
        WaveSpawner.SetActive(true);
        UI.SetActive(false);
    }
}
