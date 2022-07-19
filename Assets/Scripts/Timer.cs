using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	[SerializeField]
	private Enemy1SpawnerController controller1;
	public Enemy2SpawnerController controller2;
	[SerializeField]
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
		
		if (241 > time && time > 240)
			{

				TimerText.color = Color.white;
				phase = 3;
				controller1.spawnRate = 0.1f;
				controller2.spawnRate = 0.1f;
			}
		
		else{
			if (181 > time && time > 180)
			{
				TimerText.color = Color.black;
				phase = 3;
				controller1.spawnRate = 0.5f;
				controller2.spawnRate = 0.5f;
			}
			else {
				if (121 > time && time > 120)
				{
					TimerText.color = Color.red;
					phase = 2;
					controller1.spawnRate = 1.25f;
					controller2.spawnRate = 1.25f;
				}
				else {
					if (61> time && time >60)
					{

						TimerText.color = guicolor;
						phase = 1;
						controller1.spawnRate = 2.5f;
						controller2.spawnRate = 5.0f;
					}
				}
			} }}
}
