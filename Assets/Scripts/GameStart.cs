using Assets.Scripts.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject Bonus;
    public GameObject Trap;
    public int MaxBonus = 100;
    public int MaxTrap = 30;
    public int Spawned { get; private set; }
    public Vector3 InitialPosition { get; private set; }


    void Start()
    {
        InitialPosition = transform.position;
        BonusSpawn();
        TrapSpawn();
    }

    private void TrapSpawn()
    {
        CubeGenerator(Trap, Random.Range(1, MaxTrap));
    }

    private void Update()
    {
        CommandKeys();
    }

    private void CommandKeys()
    {
        if (Input.GetKey(KeyCode.R))
            GameActions.ResetGame();
        if (Input.GetKey(KeyCode.P))
            SetInitialPosition();
    }

    private void SetInitialPosition()
    {
        transform.position = InitialPosition;
    }

    private void BonusSpawn()
    {
        Spawned = Random.Range(1, MaxBonus);
        CubeGenerator(Bonus, Spawned);
    }

    private void CubeGenerator(GameObject cube, int n)
    {
        for (int i = 0; i < n; i++)
        {
            var randomX = Random.Range(150, 800);
            var randomZ = Random.Range(-150, 330);
            Instantiate(cube, new Vector3(randomX, 0.87f, randomZ), Quaternion.identity);
        }
    }
}
