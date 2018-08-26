using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour {

	public void OnPlayerClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
