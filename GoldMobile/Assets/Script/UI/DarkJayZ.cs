using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkJayZ : MonoBehaviour
{
    public GameObject Player;
    private GameObject Ghost;
    public GameObject CrossJayZ;
    public GameObject BubbleJayZ;
    public GameObject CurrentBubbleJayZ;
    public GameObject BloodJayZ;
    public GameObject Air;
    public GameObject TpEnd;

    private PlayerManager playerManager;
    private GhostManager ghostManager;
    private GameManager gameManager;

    private float Timer;
    public float TimerDuration;
    public float distanceDetect = 15f;

    public Transform BloodPos;

    public bool Victory = false;


    public int HurtState = 1;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ghostManager = FindObjectOfType<GhostManager>();
        Ghost = FindObjectOfType<GhostManager>().gameObject;
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameManager = FindObjectOfType<GameManager>();
        Timer = TimerDuration;
    }
    public int NbOfCross = 0;
    public enum State { Chill, Blood, Cross }
    public State BossState;
    // Update is called once per frame

    private void Awake()
    {
        FindObjectOfType<SoundManager>().SoundBoss();
    }
    void Update()
    {



        CheckHealth();

        NbOfCross = 3 * HurtState;

        if (!playerManager.isDead && !Victory)
        {
            switch (BossState)
            {
                case State.Chill:
                    JayZsChilling();
                    break;
                case State.Blood:
                    AttackJayZsBlood();
                    break;
                case State.Cross:
                    AttackCrossJayZ();
                    break;
            }
        }
        else
        {
            JayZsChilling();
        }
    }


    void CheckHealth()
    {
        if (HurtState >= 4)
        {
            Victory = true;
            TpEnd.SetActive(true);
            FindObjectOfType<PlayerManager>().transform.position = new Vector2(TpEnd.transform.position.x, transform.position.y-3);
            FindObjectOfType<GhostManager>().transform.position = new Vector2(TpEnd.transform.position.x+1, transform.position.y - 4);
            FindObjectOfType<Achievement>().UnlockBoss();
            FindObjectOfType<SoundManager>().CinMusic();
        }
    }
    void DebugKey()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            BossState = State.Chill;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            BossState = State.Blood;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            BossState = State.Cross;
        }


    }
    public IEnumerator GameOver()
    {
        if (!Player.GetComponent<PlayerManager>().isDead)
        {
            FindObjectOfType<SoundManager>().PlaySfx("Dead");
            ghostManager.ChangeControl();
            Player.GetComponentsInChildren<Animator>()[1].speed = 0;
            Player.GetComponent<PlayerManager>().isDead = true;
            Vibration.Vibrate(10);
            yield return new WaitForSeconds(5f);
            FindObjectOfType<LoaderScene>().LoadingScene(3);
        }
    }

    public void JayZsChilling()
    {

        if (CurrentBubbleJayZ != null)
        {
            t = 0f;
            // Spawn Blood rdm pos
            for (int i = 0; i < 4; i++)
            {
                Instantiate(BloodJayZ, new Vector3(Random.Range(-55, -35), Random.Range(121, 136), 1), Quaternion.identity);
            }
            Debug.Log("me now");
            Timer = TimerDuration * 3;
            Player.GetComponent<BoxCollider2D>().enabled = true;
            Player.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
            Debug.Log("ahaha ok kill me now");
            ghostManager.ChangeControl();
            Air.SetActive(false);
            Debug.Log("me noooow");
            Player.GetComponentsInChildren<Animator>()[1].SetBool("isFloating", false);
            Destroy(CurrentBubbleJayZ);
            CurrentBubbleJayZ = null;
        }
        else if (!Victory && CurrentBubbleJayZ == null)
        {
            if (Timer >= 0)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                BossState = State.Cross;

            }
        }

    }

    float TB;
    float t;
    public void AttackJayZsBlood()
    {
        CurrentBubbleJayZ.transform.position = Player.transform.position;
        Player.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;

        Player.GetComponentsInChildren<Animator>()[1].SetBool("isFloating", true);
        if (CurrentBubbleJayZ.GetComponent<BubbleJayZ>().PlayerBubbled)
        {
            Player.GetComponent<BoxCollider2D>().enabled = false;
            t += 0.008f * Time.deltaTime;
            Player.transform.position = Vector3.Lerp(Player.transform.position, BloodPos.position, t);
            if (Timer >= 0)
            {
                TB = Timer / 30;
                Timer -= Time.deltaTime;
            }
            else
            {

                StartCoroutine(GameOver());
            }
            Air.GetComponent<Image>().color = Color.Lerp(new Color(255, 255, 255, 0), new Color(255, 255, 255, 1), TB);
        }
    }
    int SpawnnedCross = 0;

    public void AttackCrossJayZ()
    {
        if (Timer >= 0)
        {
            Timer -= Time.deltaTime;
        }
        else if (Timer <= 0 && NbOfCross >= SpawnnedCross)
        {
            SpawnnedCross++;
            Timer = TimerDuration;
            Instantiate(CrossJayZ, Player.transform.position, Quaternion.identity);
        }
        else if (Timer <= 0)
        {
            CurrentBubbleJayZ = Instantiate(BubbleJayZ, Player.transform.position, Quaternion.identity);
            BossState = State.Blood;
            Air.SetActive(true);
            Timer = 25f;
            playerManager.ChangeControl();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tonneau" && BossState == State.Blood)
        {
            HurtState++;
            SpawnnedCross = 0;
            Timer = TimerDuration;
            BossState = State.Chill;
            Destroy(collision.gameObject);

        }
    }
}
