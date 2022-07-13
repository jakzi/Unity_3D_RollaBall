using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public Text timeText;
    public float speed;
    private Rigidbody rb;
    private int count;
    private float timeStart;
    private int h, m;
    private float s;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        count = 0;
        timeStart = 0;
        SetCountText();
        winText.text = "";
        timeText.text = "";
    }

    // Update is called once per frame
    private void Update()
    {
        timeStart += Time.deltaTime;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
        if(count>=12)
        {
            winText.text = "YOU WIN";
            s = timeStart;

            while (s>=60)
            {
                if (s >= 60)
                {
                    s -= 60;
                    m += 1;
                    if (m >= 60)
                    {
                        m -= 60;
                        h += 1;
                    }
                }
            }
            
            timeText.text = $"{h:00}:{m:00}:{s:00}";
            Time.timeScale = 0;
        }
    }
}
