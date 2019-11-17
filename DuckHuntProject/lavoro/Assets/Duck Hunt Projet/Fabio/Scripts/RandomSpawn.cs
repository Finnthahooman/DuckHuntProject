using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] PapereBonus = new GameObject[0];
    public GameObject[] PapereNormali = new GameObject[0];
    public GameObject[] PapereMalus = new GameObject[0];

    public float secondiTraGliSpawn = 5f;
    [Space(5)]
    

    [Range(-360f, 360f)]
    public float rangeMin = 0,rangeMax = 0;

    [Header("Percentuali di Spawn x=min / y=max")]
    public bool spawn;
    [Space(5)]
    public int percMassima = 100;
    [Space(10)]
    public Vector2 PercNormali;
    public Vector2 PercBonus;
    public Vector2 PercMalus;


    public AudioSource As;
    public AudioClip acNormale;
    public AudioClip acBonus;
    public AudioClip acMalus;

    public Vector3 _TestVector;

    public float distanzaDalloSpawn = 5;

    private void Start()
    {
        AvviaLoSpawn();
    }

    public void AvviaLoSpawn() 
    {

        StartCoroutine("SpawnaPaperaACaso");

    }

    void FermaSpawnaPapere()
    {

        StopCoroutine("SpawnaPeraACaso");

    }

    void SpawnaPaperaBonus()
    {
        As.clip = acBonus;
        As.Play();
        GameObject PaperaB = PapereBonus[Random.Range(0, PapereBonus.Length)];

        transform.rotation = Quaternion.Euler(Random.Range(rangeMin, rangeMax), 0, 0);

        GameObject PaperaBInstance = Instantiate(PaperaB,transform.position + transform.up * distanzaDalloSpawn, Quaternion.Euler(transform.forward));

       // Debug.Log(this.transform.rotation.x);

        PaperaB.GetComponentInChildren<Renderer>().sharedMaterials[1].color = Color.white;
        //PaperaB.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        PaperaBInstance.transform.LookAt(PaperaBInstance.transform.position + transform.up, Vector3.up);

    }

    void SpawnaPaperaNormale()
    {
        As.clip = acNormale;
        As.Play();
        GameObject PaperaN = PapereNormali[Random.Range(0, PapereNormali.Length)];

        transform.rotation = Quaternion.Euler(Random.Range(rangeMin, rangeMax), 0, 0);

        GameObject PaperaNInstance = Instantiate(PaperaN, transform.position + transform.up * distanzaDalloSpawn, Quaternion.Euler(transform.forward));

        PaperaNInstance.transform.LookAt(PaperaNInstance.transform.position + transform.up, Vector3.up);

    }

    void SpawnaPaperaMalus()
    {
        As.clip = acMalus;
        As.Play();
        GameObject PaperaM = PapereMalus[Random.Range(0, PapereMalus.Length)];

        transform.rotation = Quaternion.Euler(Random.Range(rangeMin, rangeMax), 0, 0);

        GameObject PaperaMInstance = Instantiate(PaperaM, transform.position + transform.up * distanzaDalloSpawn, Quaternion.Euler(transform.forward));

        PaperaM.GetComponentInChildren<Renderer>().sharedMaterials[1].color = Color.yellow;
        PaperaM.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        PaperaMInstance.transform.LookAt(PaperaMInstance.transform.position + transform.up, Vector3.up);

    }


    private void Update()
    {

            



        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnaPaperaMalus();

        }

    }

    IEnumerator SpawnaPaperaACaso2()
    {

        yield return new WaitForSeconds(secondiTraGliSpawn);

        spawn = false;

        int numeroGenerato = Random.Range(0, percMassima);


        if (numeroGenerato > PercNormali.x && numeroGenerato < PercNormali.y)
        {

            SpawnaPaperaNormale();

        }
        if (numeroGenerato > PercBonus.x && numeroGenerato < PercBonus.y)
        {

            SpawnaPaperaBonus();

        }
        if (numeroGenerato > PercMalus.x && numeroGenerato < PercMalus.y)
        {

            SpawnaPaperaMalus();

        }

        FermaSpawnaPapere();
    }


    IEnumerator SpawnaPaperaACaso()
    {

        while(spawn)
        {

            yield return new WaitForSeconds(secondiTraGliSpawn);

            int numeroGenerato = Random.Range(0, percMassima);


            if (numeroGenerato > PercNormali.x && numeroGenerato < PercNormali.y)
            {

                SpawnaPaperaNormale();

            }
            if (numeroGenerato > PercBonus.x && numeroGenerato < PercBonus.y)
            {

                SpawnaPaperaBonus();

            }
            if (numeroGenerato > PercMalus.x && numeroGenerato < PercMalus.y)
            {

                SpawnaPaperaMalus();

            }
        }
    }
}
