using UnityEngine;
using NaughtyAttributes;
using TNRD;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Input Settings")]
    [SerializeField, InputAxis] private string _horizontalAxis = "Horizontal";
    [SerializeField, InputAxis] private string _verticalAxis = "Vertical";

    [Header("Mechanics")]
    [SerializeField, Label("Movement")] private SerializableInterface<IMove> _movementMechanicSerialized;
    private IMove _movementMechanic => _movementMechanicSerialized.Value;

    [SerializeField, Label("Shoot")] private SerializableInterface<IShoot> _shootMechanicSerialized;
    private IShoot _shootMechanic => _shootMechanicSerialized.Value;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        float verticalInput = Input.GetAxisRaw(_verticalAxis);
        _movementMechanic.DoMove(horizontalInput, verticalInput);

        if(Input.GetKeyUp(KeyCode.Space))        
            _shootMechanic.DoShoot();
    }
}
