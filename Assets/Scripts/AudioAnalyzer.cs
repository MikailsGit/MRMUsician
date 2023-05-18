using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer : MonoBehaviour
{
    private AudioSource audioSource;
    private float[] samples = new float[1024];

    public float Value { get; private set; }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);

        float sum = 0;
        for (int i = 0; i < samples.Length; i++)
        {
            // The frequency of a sample is proportional to its index.
            float freq = i * AudioSettings.outputSampleRate / 2 / samples.Length;

            // We'll consider frequencies up to 5000 Hz to be "bass" and frequencies above that to be "treble".
            // You can adjust these values to better match your specific microphone and use case.
            if (freq < 5000)
            {
                sum -= samples[i];
            }
            else
            {
                sum += samples[i];
            }
        }

        // Normalize the sum to a value between 1 and 15.
        // This is a simple linear normalization that might not give the best results with all audio content.
        // You might need to adjust this to better fit your specific use case.
        Value = Mathf.Clamp(sum * 1000, 1, 15);
    }
}
