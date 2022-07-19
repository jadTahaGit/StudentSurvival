using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	private float time;
	public TextMeshProUGUI TimerText;
	private Color guicolor;
	public int phase;
	void Start()
	{
		time = 0;
		TimerText.color = Color.green;
		guicolor =new Color(0.934F, 0.739F, 0.330F, 1.0F);
		phase = 0;
	}


	void Update()
	{



		time += Time.deltaTime;
		int minutes = Mathf.FloorToInt(time / 60F);
		int seconds = Mathf.FloorToInt(time % 60F);
		int milliseconds = Mathf.FloorToInt((time * 100F) % 100F);
		TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
		if (181 > time && time > 180)
		{
			TimerText.color = Color.black;
			phase = 0;
		}
		else {
			if (121 > time && time > 120)
			{
				TimerText.color = Color.red;
				phase = 2;
			}
			else {
				if (61> time && time >60)
				{

					TimerText.color = guicolor;
					phase = 1;
				}
			}
		} }
}
