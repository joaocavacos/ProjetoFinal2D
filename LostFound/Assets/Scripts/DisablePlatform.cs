using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisablePlatform : MonoBehaviour
{

	public GameObject levels;

	private bool timerStart = false;

	private float timer = 30f;

	public Text timerText;


	void Update()
	{
		timerText.text = (Mathf.RoundToInt(timer)).ToString();
		
		if(timerStart == true)
		{
			timer -= Time.deltaTime;
		}
		else if(timerStart == false)
		{
			timer = 30f;
		}

		if(timer <= 0f)
		{
			levels.SetActive(false);
			timer = 0f;
		}
		else
		{
			levels.SetActive(true);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("StartTimer"))
		{
			timerStart = true;
		}

		if (other.CompareTag("ResetTimer"))
		{
			timerStart = false;
		}
	}


}
