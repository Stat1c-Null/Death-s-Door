using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2Script : MonoBehaviour
{
    public GameObject text;
    public GameObject compText;
    [SerializeField]
    public GameObject DoorLight;
    Light rad;
    public bool nextToDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        rad = DoorLight.GetComponent<Light>();
        text.SetActive(false);
        compText.SetActive(false);
        rad.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nextToDoor && !mazefloor.complete)
        {
            SceneManager.LoadScene("Trial2");
        }
        if (mazefloor.complete) {
            rad.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            nextToDoor = true;
            if (mazefloor.complete) {
                compText.SetActive(true);
                text.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            nextToDoor = false;
            compText.SetActive(false);
        }
    }
}
