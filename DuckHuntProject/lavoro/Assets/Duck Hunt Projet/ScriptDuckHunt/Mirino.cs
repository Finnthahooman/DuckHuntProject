using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirino : MonoBehaviour
{
    public LevelManager levelManager;
    const int scorePerDuck = 3;
    const int ammoPerDuck = 2;
    const int scoreToWin = 100;
    public int numeroPapere = 20;

    public AudioClip[] spari;
    public AudioSource As;

    public Camera cam;
    public GameObject arma;
    public int maxDistance = 5;
    public int score = 0;

    public GameObject particleSys;

    public int bullets = 60;
 
    
    

    private void Awake()
    {
        cam = Camera.main;
    }

    
    void FixedUpdate()
    {
        
        Vector3 screenPoint = Input.mousePosition + new Vector3(0,0,1);
        Vector3 worldPos = cam.ScreenToWorldPoint(screenPoint);
        this.transform.position = worldPos;
        
       
           if (Input.GetMouseButtonDown(0))
           {
                As.clip = spari[Random.Range(0, spari.Length)];
                As.Play();
                bullets--;
                RaycastHit hit;
                if (Physics.Raycast(cam.transform.position, (worldPos - cam.transform.position).normalized, out hit, maxDistance))
                //if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, maxDistance))
                {

                    if (hit.collider.gameObject.tag == "duck")
                    {
                        instantiateParticles(hit);
                        Duck d = hit.collider.gameObject.GetComponent<Duck>();
                        
                        DanneggiaPapera(d, 1);


                    }
                    else if (hit.collider.gameObject.tag == "headShot")
                    {
                        instantiateParticles(hit);
                        DuckHead h = hit.collider.gameObject.GetComponent<DuckHead>();
                        Duck d = h.owner;
                        if (d.vita == 2)
                        {
                           
                            DanneggiaPapera(d, 2, 3);
                        }
                        else if (d.vita == 1)
                        {

                            DanneggiaPapera(d, 2, 2);
                        }
  
                    }

                levelManager.BulletCheck(bullets);
             
                }
           }

    }

    private void instantiateParticles(RaycastHit hit)
    {

        particleSys.transform.position = hit.point;
        ParticleSystem ps = particleSys.GetComponent<ParticleSystem>();
        ps.Emit(5);

    }

    public void DanneggiaPapera(Duck duck, int damage, float pointsMultiplier = 1)
    {
        duck.Danneggia(damage);
        if (duck.tipo == Duck.TIPI_DI_PAPERE.RIGHT_DUCK)
        {
            score += Mathf.RoundToInt(scorePerDuck * pointsMultiplier);
        }
        else if (duck.tipo == Duck.TIPI_DI_PAPERE.WRONG_DUCK)
        {
            score -= scorePerDuck;
        }
        else if (duck.tipo == Duck.TIPI_DI_PAPERE.BONUS_DUCK)
        {
            bullets += Mathf.RoundToInt(ammoPerDuck * pointsMultiplier);
        }
        
    
    }

    private void OnGUI()
    {
        /*
        GUI.Label(new Rect(10f, 10f, 150f, 20f), "punteggio: " + score );
        GUI.Label(new Rect(10f, 40f, 150f, 20f), "proiettili: " + bullets);
        GUI.Label(new Rect(10f, 70f, 150f, 20f), "papere rimaste: " + numeroPapere);
        */
    }
}
