using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Difficulty(float difficulty)
    {
        if (difficulty == 0f)
        {
            AiPlayer.shootingRadiusThreshold = 7f;
            AiPlayer.shootingDelayInSeconds = 2f;
            AiPlayer.shootingNoiseFactor = 10f;
        }
        else
        {
            AiPlayer.shootingRadiusThreshold = difficulty * 40f;
            AiPlayer.shootingDelayInSeconds = (1f - difficulty) * 2f;
            AiPlayer.shootingNoiseFactor = (1f - difficulty) * 10f;
        }
    }
}
