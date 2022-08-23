using Snake;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject tipsPanel;
	[SerializeField] private GameObject restartPanel;
	[SerializeField] private StatisticsSO snakeStatistics;

	public void GameScene()
	{
		SceneManager.LoadScene(1);
	}

	public void MenuScene()
	{
		SceneManager.LoadScene(0);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void Options()
	{
		// TODO
	}

	public void PauseGame()
	{
		if (snakeStatistics.IsGamePaused)
		{
			Resume();
		}
		else
		{
			Pause();
		}
	}

	public void RestartPanel()
	{
		restartPanel.SetActive(true);
		Time.timeScale = snakeStatistics.FreezeTime;

	}

	public void Restart() 
	{
		restartPanel.SetActive(false);
		GameScene();
	}


	private void Resume()
	{
		pausePanel.SetActive(false);
		tipsPanel.SetActive(true);
		Time.timeScale = snakeStatistics.StoredTime;
		snakeStatistics.IsGamePaused = false;
	}

	private void Pause()
	{
		pausePanel.SetActive(true);
		tipsPanel.SetActive(false);
		Time.timeScale = snakeStatistics.FreezeTime;
		snakeStatistics.IsGamePaused = true;
	}
}
