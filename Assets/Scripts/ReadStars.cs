using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadStars : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        DataManager datam = DataManager.instance;
        switch (datam.progress.stars[level])
        {
            case 0:
                break;
            case 1:
                star1.SetActive(true);
                break;
            case 2:
                star1.SetActive(true);
                star2.SetActive(true);
                break;
            case 3:
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                break;
        }
    }

}
