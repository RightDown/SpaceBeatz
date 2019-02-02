using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rocket : MonoBehaviour
{

    public float Life
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
            healthBar.fillAmount = life / 100;
        }
    }
    public Image healthBar;

    [Header("Health(Only for viewing)")]
    [SerializeField]
    private float life = 100;

    void Update()
    {
        if (Life <= 0)
        {
            Debug.Log("Rocket exploded!");
            //do somenthing
        }
    }
}
