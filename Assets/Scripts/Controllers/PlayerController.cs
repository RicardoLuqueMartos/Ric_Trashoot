using UnityEngine;
using NaughtyAttributes;
using TNRD;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameUIManager gameUIManager;

    [Header("Enemies Pool controller")]
    [SerializeField]
    EnemyPool enemyPool;

    [Header("Input Settings")]
    [SerializeField, InputAxis] private string _horizontalAxis = "Horizontal";
    [SerializeField, InputAxis] private string _verticalAxis = "Vertical";

    [Header("Mechanics")]
    [SerializeField, Label("Movement")] private SerializableInterface<IMove> _movementMechanicSerialized;
    private IMove _movementMechanic => _movementMechanicSerialized.Value;

    [SerializeField, Label("Shoot")] private SerializableInterface<IShoot> _shootMechanicSerialized;
    private IShoot _shootMechanic => _shootMechanicSerialized.Value;
    #endregion Variables

    private void OnEnable()
    {
        if (enemyPool != null)      
            enemyPool.gameObject.SetActive(true);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        float verticalInput = Input.GetAxisRaw(_verticalAxis);
        _movementMechanic.DoMove(horizontalInput, verticalInput);

        if(Input.GetKeyUp(KeyCode.Space))        
            _shootMechanic.DoShoot();
    }
    private void OnDisable()
    {
        if (enemyPool != null)
        {
            enemyPool.StopPool();
            enemyPool.ResetPool();
            enemyPool.gameObject.SetActive(false);
        }
    }

    public void EndGame()
    {
        enemyPool.ResetPool();
        enemyPool.gameObject.SetActive(false);
        gameUIManager.EndGame();
    }

    public void AddToScore()
    {
        gameUIManager.AddToScore();
    }
}
