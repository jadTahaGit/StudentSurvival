using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
	[SerializeField] private AudioMixer MenuMixer;

	public void SetVolume(float sliderValue)
	{
		MenuMixer.SetFloat("MenuMaster", Mathf.Log10(sliderValue) * 20);
	}
}
