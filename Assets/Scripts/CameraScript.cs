using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickStartButton();
    }

    private void ClickStartButton() {
        GameObject canvas = GameObject.Find("Canvas");
        Transform startButtonTransfrom = canvas.transform.Find("StartButton");
        Button startButton = startButtonTransfrom.GetComponent<Button>();
        startButton.onClick.AddListener(this.GoToScene);
    }

    private void GoToScene() {
        Debug.Log("load next scene");
        SceneManager.LoadScene("Scene1");
    }
}
