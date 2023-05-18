using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizationManager : MonoBehaviour
{
        AudioSource audioSource;
        public static float[] samples = new float[512];
        public static float[] freqBand = new float[8];
        public static float[] bandBuffer = new float[8];
        float[] bufferDecrease = new float[8];

        float[] freqBandHighest = new float[8];
        public static float[] audioBand = new float[8];
        public static float[] audioBandBuffer = new float[8];
        public float audioProfile;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            AudioProfile(audioProfile);
        }

        // Update is called once per frame
        void Update()
        {
            GetAudioSpectrum();
            MakeFrequencyBands();
            BandBuffer();
            CreateAudioBands();
        }

        void AudioProfile(float audioProfile)
        {
            for (int i = 0; i < 8; i++)
            {
                freqBandHighest[i] = audioProfile;
            }
        }

        void GetAudioSpectrum()
        {
            audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        }

        void BandBuffer()
        {
            for (int i = 0; i < 8; ++i)
            {
                if (freqBand[i] > bandBuffer[i])
                {
                    bandBuffer[i] = freqBand[i];
                    bufferDecrease[i] = 0.00005f;
                }

                if (freqBand[i] < bandBuffer[i])
                {
                    bandBuffer[i] -= bufferDecrease[i];
                    bufferDecrease[i] *= 1.2f;
                }
            }
        }

        void CreateAudioBands()
        {
            for (int i = 0; i < 8; i++)
            {
                if (freqBand[i] > freqBandHighest[i])
                {
                    freqBandHighest[i] = freqBand[i];
                }
                audioBand[i] = (freqBand[i] / freqBandHighest[i]);
                audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
            }
        }

        void MakeFrequencyBands()
        {
            int indexSample = 0;

            for (int i = 0; i < 8; i++)
            {
                float average = 0;
                int sampleCount = (int)Mathf.Pow(2, i) * 2;

                if (i == 7)
                {
                    sampleCount += 2;
                }

                for (int j = 0; j < sampleCount; j++)
                {
                    average += samples[indexSample] * (indexSample + 1);
                    indexSample++;
                }

                average /= indexSample;
                freqBand[i] = average * 10;
            }
        }
    }
