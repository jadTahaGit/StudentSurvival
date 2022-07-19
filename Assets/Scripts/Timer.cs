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
		TimerText.color = Color.green;
	}


	void Update()
	{



		time += Time.deltaTime;
		int minutes = Mathf.FloorToInt(time / 60F);
		int seconds = Mathf.FloorToInt(time % 60F);
		int milliseconds = Mathf.FloorToInt((time * 100F) % 100F);
		TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
		if (time > 180)
		{
			TimerText.color = Color.black;

		}
		else {
			if (time > 120)
			{
				TimerText.color = Color.red;

			}
			else {
				if (time >60)
				{

					TimerText.color = new Color(0.934F, 0.739F, 0.330F, 1.0F);
				}
			}
		} }
}
