using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failSceneCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isLoser", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
