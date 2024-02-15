using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public Text textComponent; 

    private void Update()
    {
        if (waveSpawner != null && textComponent != null)
        {
            if (waveSpawner.currentWaveIndex < waveSpawner.waves.Length)
            {
                int enemiesLeft = waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft;
                int currentWave = waveSpawner.currentWaveIndex + 1; 
                textComponent.text = "Wave: " + currentWave + "  Enemies Left: " + enemiesLeft;
            }
            else
            {
                textComponent.text = "All waves completed!";
            }
        }
    }
}
