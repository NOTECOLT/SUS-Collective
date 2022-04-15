using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour {
	public Animator transition;
	public GameTimer _gt;
    public void LoadScene(string name) {
        StartCoroutine(Transition(name));
    }

    public void LoadSceneFromPause(string name) {
		Time.timeScale = 1;
        StartCoroutine(Transition(name));
    }


	public void LoadSceneNoTrans(string name) {
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

    public void QuitGame() {
        Debug.Log("Application Ended");
        Application.Quit();
    }

	IEnumerator Transition(string name)
	{//fsr the fade to black isnt working pero the fade in is? im confused and its almost 4am idk man
	//this is what i was following HAHAHAH https://www.youtube.com/watch?v=CE9VOZivb3I&ab_channel=Brackeys is it a me problem,
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void GameOver() {
		if (_gt.isEndless)
			LoadScene("GameOverEndless");
		else
			LoadScene("GameOver");
	}
}