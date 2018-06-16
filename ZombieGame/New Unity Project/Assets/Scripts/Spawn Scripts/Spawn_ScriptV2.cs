using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace S3
{
    public class Spawn_ScriptV2 : MonoBehaviour
    {
        public int Heavy_Zombie_Speed;
        public int Heavy_Zombie_Damage;
        public int Fast_Zombie_Speed;
        public int Fast_Zombie_Damage;
        public int Regular_Zombie_Speed;
        public int Regular_Zombie_Damage;
        public enum spawnState { SPAWNING, WAITING, COUNTING };
        public Material regular_zombie;
        public Material Heavy_zombie;
        public Material fast_zombie;
        private int round = 1;
        public static List<Transform> spawnPoints = new List<Transform>();         // An array of the spawn points this enemy can spawn from.
        public int AmountOfEnemies = 10;
        public int IncreaseEnemiesBy = 2;
        public float spawnDelay = 1.0f;
        public float timeBetweenWaves = 5.0f;
        public int increaseEnemyHealth;
        private float waveCountdown;
        private float searchCountdown = 1.0f;
        public TextMesh roundText;
        public AudioClip nextRound;
        public Transform myTransform;

        private spawnState state = spawnState.COUNTING;

        void Start()
        {
            GameObject Spawner = GameObject.Find("Spawner");
            Transform SpawnerTransform = Spawner.transform;
            spawnPoints.Add(SpawnerTransform);

            GameObject Spawner_1 = GameObject.Find("Spawner_1");
            Transform SpawnerTransform1 = Spawner_1.transform;
            spawnPoints.Add(SpawnerTransform1);

            SetUI();
            waveCountdown = timeBetweenWaves;
            if (spawnPoints.Count == 0)
            {
                Debug.LogError("NO SPAWN POINTS");
            }


        }

        void Update()
        {
            // Debug.Log("COUNT IS:::::::::::::" + spawnPoints.Count);
            if (state == spawnState.WAITING)
            {
                if (EnemyIsAlive())
                {
                    return;
                }
                else
                {
                    WaveCompleted();
                }
            }

            if (waveCountdown <= 0)
            {
                if (state != spawnState.SPAWNING)
                {

                    StartCoroutine(SpawnWave());
                    state = spawnState.WAITING;
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }


        bool EnemyIsAlive()
        {
            searchCountdown -= Time.deltaTime;

            if (searchCountdown <= 0f)
            {
                searchCountdown = 1f;
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    return false;
                }
            }
            return true;
        }

        IEnumerator SpawnWave()
        {
            GameObject enemy = (GameObject)Resources.Load("golem");
            if ((round % 2 == 0) && (round % 5 != 0)) // FAST ZOMBIES SPAWN
            {
                enemy.transform.GetChild(1).GetComponent<Renderer>().sharedMaterial = fast_zombie;
                enemy.GetComponent<NavMeshAgent>().speed = Fast_Zombie_Speed;
                enemy.GetComponent<Enemy_Attack>().attackDamage = Fast_Zombie_Damage;
                state = spawnState.SPAWNING;

                for (int i = 0; i < AmountOfEnemies; i++)
                {
                    SpawnEnemies(enemy);
                    yield return new WaitForSeconds(spawnDelay);

                }
                enemy.GetComponent<Enemy_Health>().enemyHealth += increaseEnemyHealth;
                AmountOfEnemies = AmountOfEnemies + IncreaseEnemiesBy;
                state = spawnState.WAITING;

                yield break;
            }
            if (round % 5 == 0) // Heavy zombies spawn
            {
                enemy.transform.GetChild(1).GetComponent<Renderer>().sharedMaterial = Heavy_zombie;
                enemy.GetComponent<NavMeshAgent>().speed = Heavy_Zombie_Speed;
                enemy.GetComponent<Enemy_Attack>().attackDamage = Heavy_Zombie_Damage;
                state = spawnState.SPAWNING;

                for (int i = 0; i < AmountOfEnemies; i++)
                {
                    SpawnEnemies(enemy);
                    yield return new WaitForSeconds(spawnDelay);

                }
                enemy.GetComponent<Enemy_Health>().enemyHealth += increaseEnemyHealth;
                AmountOfEnemies = AmountOfEnemies + IncreaseEnemiesBy;
                state = spawnState.WAITING;

                yield break;
            }
            else //regular zombies spawn
            {
                enemy.transform.GetChild(1).GetComponent<Renderer>().sharedMaterial = regular_zombie;
                enemy.GetComponent<NavMeshAgent>().speed = Regular_Zombie_Speed;
                enemy.GetComponent<Enemy_Attack>().attackDamage = Regular_Zombie_Damage;
                state = spawnState.SPAWNING;

                for (int i = 0; i < AmountOfEnemies; i++)
                {
                    SpawnEnemies(enemy);
                    yield return new WaitForSeconds(spawnDelay);

                }
                enemy.GetComponent<Enemy_Health>().enemyHealth += increaseEnemyHealth;
                AmountOfEnemies = AmountOfEnemies + IncreaseEnemiesBy;
                state = spawnState.WAITING;

                yield break;
            }
        }

        void SpawnEnemies(GameObject enemy)
        {
            int range_num = spawnPoints.Count;
            int spawnPointIndex = Random.Range(0, range_num);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position + Random.insideUnitSphere * 3, spawnPoints[spawnPointIndex].rotation);

        }

        void WaveCompleted()
        {

            state = spawnState.COUNTING;
            round++;
            SetUI();
            waveCountdown = timeBetweenWaves;
        }

        void SetUI()
        {
            if (roundText != null)
            {
                roundText.text = round.ToString();
            }
                AudioSource.PlayClipAtPoint(nextRound, myTransform.position + myTransform.forward*4,90.5f);
                AudioSource.PlayClipAtPoint(nextRound, myTransform.position + myTransform.forward * -4, 90.5f);
                AudioSource.PlayClipAtPoint(nextRound, myTransform.position + myTransform.right * 4, 90.5f);
                AudioSource.PlayClipAtPoint(nextRound, myTransform.position + myTransform.right * -4, 90.5f);
            
        }
    }
}




