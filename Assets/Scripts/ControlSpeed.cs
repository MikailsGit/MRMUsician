using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpeed : MonoBehaviour
{
    private Material material;
    private int speedPropertyID = Shader.PropertyToID("_Speed");

    [Range(0f, 60f)]
    public float actualFreq = 1f;
    private float maxFreq = 60.0f;
    private float percentage;

    [SerializeField, Range(0, 7)] public int audioBand = 0;
    // Start is called before the first frame update
    void Start()
    {
        material = this.gameObject.GetComponent<MeshRenderer>().sharedMaterial;
        percentage = actualFreq / maxFreq;
    }

    // Update is called once per frame
    void Update()
    {
        actualFreq = AudioVisualizationManager.bandBuffer[audioBand] * 10;
        actualFreq = Mathf.Clamp(actualFreq, 0f, 60f);
        Debug.Log(actualFreq);

        percentage = actualFreq / maxFreq;
        float mod_speed = (percentage * 0.75f) + 0.25f;
        material.SetFloat(speedPropertyID, mod_speed);
    }
    
}
