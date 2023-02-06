using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rg;
    bool walkingRight = true;
    public Transform rayStart;
    private Animator anim;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        rg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.isGameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("GameStarted");
        }
        rg.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }
        RaycastHit hit;
        if(!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity)){
            anim.SetTrigger("IsFalling");
        }

        if(transform.position.y < -2)
        {
            gameManager.EndGame();
        }
    }

    private void Switch()
    {
        if (!gameManager.isGameStarted)
        {
            return;
        }
        walkingRight = !walkingRight;

        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Crystal")
        {
            Destroy(other.gameObject);
            gameManager.IncreaseGameScore();
            Debug.Log("Updated Score" + gameManager.getScoreCount());
        }
    }
}
