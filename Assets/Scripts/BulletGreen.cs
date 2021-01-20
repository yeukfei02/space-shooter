using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletGreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject bulletClone = GameObject.Find("BulletGreen(Clone)");
        Destroy(bulletClone, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("collision.gameObject = " + collision.gameObject);

        if (collision.gameObject.name == "EnemyShip(Clone)" || collision.gameObject.name == "EnemyUFO(Clone)" || collision.gameObject.name == "StoneBig(Clone)" || collision.gameObject.name == "StoneSmall(Clone)") {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            GameObject canvas = GameObject.Find("Canvas");
            Transform scoreTextTransfrom = canvas.transform.Find("ScoreText");
            Text scoreText = scoreTextTransfrom.GetComponent<Text>();
            Plane.score += 1;

            scoreText.text = "Score: " + Plane.score;
        }
    }
}
