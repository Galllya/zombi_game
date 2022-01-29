using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent navMeshAgent;
    public float moveSpeed;
    Cursor cursor;
    Shot shot;
    public Transform gunBarrel;
    public  int curentHealth;
    public bool isDead;
    Spawn spawn;
    FirstAID firstAID1;
    ResetGameButton resetGameButton;
    

    void Start()
    {
        cursor = FindObjectOfType<Cursor>();
        shot = FindObjectOfType<Shot>();
        spawn = FindObjectOfType<Spawn>();
        resetGameButton = FindObjectOfType<ResetGameButton>();


        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        isDead = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Vector3 dir = Vector3.zero;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                dir.x = -1.0f;
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                dir.x = 1.0f;
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                dir.z = 1.0f;
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                dir.z = -1.0f;
            navMeshAgent.velocity = dir.normalized * moveSpeed;

            if (Input.GetMouseButtonDown(0))
            {
                var from = gunBarrel.position;
                var target = cursor.transform.position;
                var to = new Vector3(target.x, from.y, target.z);

                var direction = (to - from).normalized;

                RaycastHit hit;
                if (Physics.Raycast(from, direction, out hit, 100))
                {

                    if (hit.transform != null)
                    {
                        var zombi = hit.transform.GetComponent<Zombi>();
                        if (zombi != null)
                        {
                            zombi.Kill();
                        }

                    }
                    to = new Vector3(hit.point.x, from.y, hit.point.z);
                }
                else
                {
                    to = from + direction * 100;
                }
                shot.Show(from, to);
            }

            Vector3 forvard = cursor.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(new Vector3(forvard.x, 0, forvard.z));
        }

        if (curentHealth<0)
        {
            isDead = true;

            resetGameButton.gameObject.SetActive(true);

           // SceneManager.LoadScene("SampleScene");


        }

        if (isDead)
        {

            
            Invoke(nameof (PlayerDied), 5f);
        }
    }


    private void PlayerDied()
    {
        gameObject.SetActive(false);
      

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent( out Zombi zombi))
        {
            curentHealth -= 20;
        }

    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FirstAID firstAID))
        {
            if (curentHealth + 50 >200)
            {
                curentHealth = 200;
            }
            else
            {
                curentHealth += 50;
            }
            
            
            firstAID.gameObject.SetActive(false);
            firstAID1 = firstAID;
            Invoke(nameof(StartAID), 20f);



        }

    }

    private void StartAID()
    {

        firstAID1.gameObject.SetActive(true);


    }

    private void OnCollisionStay(Collision collision)
    {
      /*  if (collision.gameObject.TryGetComponent(out Zombi zombi))
        {
            curentHealth -= 5;
        }*/
    }
}
