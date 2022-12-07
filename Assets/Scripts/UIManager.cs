using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretext, hptext, ammotext;
    public float score, hp, ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = $@"SCORE:{score}";
        hptext.text = $@"HP:{hp}";
        ammotext.text = $@"Heat:{ammo}°";
    }
}
