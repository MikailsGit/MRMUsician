using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    private AudioSource audioSource;
    private string selectedDevice;

    void Start()
    {
        selectedDevice = Microphone.devices[0].ToString();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(selectedDevice, true, 10, 44100);
        audioSource.loop = true; 

        
        while (!(Microphone.GetPosition(selectedDevice) > 0)) { }
        audioSource.Play();
    }
}
