using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeJugadores : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] GameObject panel2;
    [SerializeField] GameObject panel3;
    [SerializeField] GameObject panel4;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Scientist")
        {
            print("Hola Mundo");
            panel.SetActive(true);
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            panel.SetActive(false);
            panel2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            panel2.SetActive(false);
            panel3.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            panel3.SetActive(false);
            panel4.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Scientist")
        {
            panel.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);
        }
    }

    
}
