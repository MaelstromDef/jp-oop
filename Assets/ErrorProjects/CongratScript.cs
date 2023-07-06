using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> TextToDisplay = new List<string>();

    public float RotatingSpeed;
    public float TextTime;
    private float TimeToNextText;

    private int CurrentText;

    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;

        TextToDisplay.Add("Congratulations");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[CurrentText];

        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Text.transform.Rotate(0f, Time.deltaTime * RotatingSpeed, 0f);  // Rotate text
        TimeToNextText += Time.deltaTime;

        // Wooo next text!!
        if (TimeToNextText > TextTime)
        {
            TimeToNextText = 0.0f;
            CurrentText++;
            
            if (CurrentText >= TextToDisplay.Count) CurrentText = 0;    // Maintain Boundaries

            Text.text = TextToDisplay[CurrentText];                     // Don't forget next text doofus
        }
    }
}