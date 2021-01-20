using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public static int life = 3;
    public static int score = 0;

    public GameObject bulletRed;
    public GameObject bulletGreen;
    private readonly float buttetRedSpeed = 500f;
    private readonly float buttetGreenSpeed = 1000f;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject plane = GameObject.Find("Plane");

        KeyBoardMoveControl(plane);
    }

    private void KeyBoardMoveControl(GameObject plane) {
        float moveSpeed = 0.3f;

        if (Input.GetKey(KeyCode.UpArrow)) {
            plane.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y + moveSpeed, plane.transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            plane.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y - moveSpeed, plane.transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            plane.transform.position = new Vector3(plane.transform.position.x - moveSpeed, plane.transform.position.y, plane.transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            plane.transform.position = new Vector3(plane.transform.position.x + moveSpeed, plane.transform.position.y, plane.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject bullet = bulletRed;
            float buttetSpeed = buttetRedSpeed;
            if (score > 10) {
                bullet = bulletGreen;
                buttetSpeed = buttetGreenSpeed;
            }

            GameObject bulletClone = Instantiate(bullet, plane.transform.position, plane.transform.rotation);
            Rigidbody2D rigidbody2D = bulletClone.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(bulletClone.transform.up * buttetSpeed);

            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("collision.gameObject = " + collision.gameObject);

        if (collision.gameObject.name == "EnemyShip(Clone)" || collision.gameObject.name == "EnemyUFO(Clone)" || collision.gameObject.name == "StoneBig(Clone)" || collision.gameObject.name == "StoneSmall(Clone)") {
            life -= 1;
            Destroy(collision.gameObject);

            switch (life) {
                case 2:
                    GameObject life3 = GameObject.Find("Life3");
                    life3.SetActive(false);
                    break;
                case 1:
                    GameObject life2 = GameObject.Find("Life2");
                    life2.SetActive(false);
                    break;
                case 0:
                    GameObject life = GameObject.Find("Life");
                    life.SetActive(false);

                    GameObject canvas = GameObject.Find("Canvas");
                    canvas.SetActive(false);

                    Debug.Log("Game over!");
                    Destroy(gameObject);
                    PauseGame();
                    break;
            }
        }
    }

    private void PauseGame() {
        Time.timeScale = 0;
    }
}
