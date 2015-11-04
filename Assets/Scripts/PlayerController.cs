using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    #region UNITY_EDITOR
    public float speed;
    public Text tScore, tWin;
    public Button btRestart;
    #endregion
    private Rigidbody rg;
    private int score;

    // Use this for initialization
    void Start() {
        rg = GetComponent<Rigidbody>();
        score = 0;
        DisplayScore();
        tWin.enabled = false;
        btRestart.gameObject.SetActive(false);
        btRestart.onClick.AddListener(() => OnClickButtonRestart());
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rg.AddForce(move * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickme"))
        {
            other.gameObject.SetActive(false);
            score++;
            DisplayScore();
        }
    }

    public void DisplayScore()
    {
        tScore.text = "Score:" + score;
        if (score == 13)
        {
            tWin.enabled = true;
            btRestart.gameObject.SetActive(true);
        }
    }
        public void OnClickButtonRestart()
    {
        Application.LoadLevel("MiniGame");
    }

}
