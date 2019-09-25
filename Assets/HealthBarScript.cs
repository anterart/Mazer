using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image healthImage;
    // Start is called before the first frame update
    void Start()
    {
        healthImage.fillAmount = 1f;
    }
}
