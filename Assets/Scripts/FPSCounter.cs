using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public float timer, refresh, avgFramerate;
    public Text fpsholder;
    // protected string ValueToString(float v);
    // Start is called before the first frame update
    // void Start()
    // {
    // fpsholder = GameObject.FindWithTag("fps");
    // }

    // Update is called once per frame
    void Update()
    {
        timer = timer <= 0 ? refresh : timer -= Time.smoothDeltaTime;

        if (timer <= 0) avgFramerate = (int)(1f / Time.smoothDeltaTime);
        // var fps = 
        fpsholder.text = avgFramerate.ToString();
    }
}
