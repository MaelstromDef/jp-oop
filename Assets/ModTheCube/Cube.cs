using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [Header("Visuals")]
    public MeshRenderer Renderer;
    public Color color;
    [Header("Rotate")]
    public float speed = 1f;
    [Header("Oscillate")]
    public float distance;
    public float time;
    float stopwatch = 0f;
    int direction = 1;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = color;
    }
    
    void Update()
    {
        stopwatch += Time.deltaTime;

        if (stopwatch > time)
        {
            stopwatch = 0;
            direction *= -1;
        }

        transform.Rotate(10.0f * Time.deltaTime * speed, 0.0f, 0.0f);
        float newPos = Mathf.Lerp((4 + distance * direction * -1), 4 + distance * direction, stopwatch / time);
        transform.position = new Vector3(3, newPos, 1);
    }
}
