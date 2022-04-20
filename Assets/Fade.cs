using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    [SerializeField] private CanvasGroup myUIGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        myUIGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(myUIGroup.alpha < 1)
        {
            myUIGroup.alpha += Time.deltaTime;
            if(myUIGroup.alpha > 1)
            {
                myUIGroup.alpha = 1;
            }
        }
    }

}
