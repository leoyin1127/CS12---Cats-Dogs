using UnityEngine;
using UnityEngine.UI;

public class scoretext : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public int point = 0;

    // Update is called once per frame
    void Update()
    {   
        scoreText.text = point.ToString();
    }
}
