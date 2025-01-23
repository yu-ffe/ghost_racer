using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class GamePlay : MonoBehaviour {

    public GameObject[] planes;
    public GameObject ball;

    private List<GameObject> planeList = new List<GameObject>();
    private List<GameObject> ballList = new List<GameObject>();

    private int hp = 100;
    private Text HP_text;
    
    private float lastTime = 0f;  // 마지막으로 n을 증가시킨 시간
    private float timeInterval = 0.01f;  // 1초마다 n 증가

    void Start() {
        HP_text = GameObject.Find("Canvas/HP").GetComponent<Text>();
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 8; j++) {
                GameObject plane = Instantiate(planes[Random.Range(0, planes.Length)]);
                plane.transform.position = new Vector3(i, 0, j * 2);
                planeList.Add(plane);
            }
        }
        for (int j = 0; j < 8; j++) {
            GameObject copyBall = Instantiate(ball);
            copyBall.transform.position = new Vector3(Random.Range(0, 3), 0, j * 2);
            ballList.Add(copyBall);
        }

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            OnMove(false);
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            OnMove(true);
        }
        if (Time.time - lastTime >= timeInterval)
        {
            lastTime = Time.time;  // 마지막 증가 시간을 현재 시간으로 갱신
            hp--;
            HP_text.text = hp.ToString();

            if (hp <= 0) {
                new SceneLoader().OnLoad("GameOver");
            }
            
            foreach (var plane in planeList) {
                if (plane.transform.position.z < -1.99f) {
                    plane.transform.position = new Vector3(plane.transform.position.x, 0, 14);
                }
                plane.transform.position += new Vector3(0, 0, -0.1f);
            }
            foreach (var copyBall in ballList) {
                if (copyBall.transform.position.z < -1.99f) {
                    copyBall.transform.position = new Vector3(Random.Range(0, 3), 0, 14);
                    copyBall.GetComponent<Renderer>().enabled = true;
                }
                copyBall.transform.position += new Vector3(0, 0, -0.1f);
                if (Vector3.Distance(copyBall.transform.position, transform.position) <= 0.5) {
                    Renderer renderer = copyBall.GetComponent<Renderer>();
                    if (renderer.enabled == false) continue;
                    renderer.enabled = false;
                    hp += 20;
                }
            }
        }
    }

    public void OnMove(bool direct) {
        if (direct) {
            if (transform.position.x > 0.5) {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else {
            if (transform.position.x < 1.5) {
                transform.position += new Vector3(1, 0, 0);
            }
        }
    }
}
