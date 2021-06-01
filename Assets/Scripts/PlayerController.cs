using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;
    public ParticleSystem dirt;
    public ParticleSystem explosion;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private float jumpForce = 1100;
    private float gravityMultiplier = 5f;
    private bool isGrounded;
    private Rigidbody playerRb;
    private Animator anim;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        gameOver = false;
        audioSource = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
        anim = GetComponent<Animator>();
        dirt.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            Jump();
        }
        int currentScore = FindObjectOfType<ScoreManager>().GetScore();
        anim.speed += currentScore * 0.0000002f;
    }

    private void Jump()
    {
        audioSource.PlayOneShot(jumpSound, 1);
        dirt.Stop();
        anim.SetTrigger("Jump_trig");
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            if (!gameOver)
                dirt.Play();
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            audioSource.PlayOneShot(crashSound, 1);
            explosion.Play();
            dirt.Stop();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            gameOver = true;
            Debug.Log("Game Over!");
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public void ResetPlayer()
    {
        gameObject.transform.position = Vector3.zero;
        anim.SetBool("Death_b", false);
        anim.Play("Run_Static");
    }
}
