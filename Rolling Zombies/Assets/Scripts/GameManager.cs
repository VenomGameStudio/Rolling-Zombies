using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int selectedzombiePosition = 0;
    public Text scoreText;
    public int score = 0;
    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 selectedSize;
    public Vector3 originalSize;

    // Start is called before the first frame update
    void Start()
    {
        SelectedZombie(selectedZombie);
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
            GetZombieLeft();
        if (Input.GetKeyDown("right"))
            GetZombieRight();
        if (Input.GetKeyDown("up"))
            PushUp();
    }

    void GetZombieLeft()
    {
        if (selectedzombiePosition == 0)
        {
            selectedzombiePosition = 3;
            SelectedZombie(zombies[3]);
        }
        else
        {
            selectedzombiePosition -= 1;
            SelectedZombie(zombies[selectedzombiePosition]);
        }
    }

    void GetZombieRight()
    {
        if (selectedzombiePosition == 3)
        {
            selectedzombiePosition = 0;
            SelectedZombie(zombies[0]);
        }
        else
        {
            selectedzombiePosition += 1;
            SelectedZombie(zombies[selectedzombiePosition]);
        }
    }

    void PushUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }

    void SelectedZombie(GameObject newZombie)
    {
        selectedZombie.transform.localScale = originalSize;
        selectedZombie = newZombie;
        newZombie.transform.localScale = selectedSize;
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score : " + score;
    }
}
