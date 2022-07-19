using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	private float time;
	public TextMeshProUGUI TimerText;
	void Start()
	{
		time = 0;
	}

		void Update()
	{
		
		

			time += Time.deltaTime;
			int minutes = Mathf.FloorToInt(time / 60F);
			int seconds = Mathf.FloorToInt(time % 60F);
			int milliseconds = Mathf.FloorToInt((time * 100F) % 100F);
			TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
		

	}
}
