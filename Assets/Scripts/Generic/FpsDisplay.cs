using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FpsDisplay : MonoBehaviour
{

    public bool showFps;

    private float fps;
    private float deltaTime;
    public TextMeshProUGUI fpsCount;

    public TextMeshProUGUI enemyCounter;
    public TextMeshProUGUI win;

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        fps = 1.0f / deltaTime;
        fpsCount.text = "FPS: " + Mathf.RoundToInt(fps).ToString();
        ContadorEnemigos();
    }


    public void ContadorEnemigos()
    {
        enemyCounter.text = $"Has eliminado {GameManager.Instance.enemyDefeated} de {GameManager.Instance.totalEnemiesToDefeat}";
        if (GameManager.Instance.enemyDefeated >= GameManager.Instance.totalEnemiesToDefeat)
        {
            Time.timeScale = 0f;
            win.gameObject.SetActive(true);
        }
    }

}
