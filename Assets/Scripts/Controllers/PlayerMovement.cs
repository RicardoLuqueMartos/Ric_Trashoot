using UnityEngine;
using NaughtyAttributes;
using TNRD;
using UnityEngine.Events;

public class PlayerMovement : Movement
{
   

    [Header("Event")]
    [SerializeField] private UnityEvent<float> _onMove;

    public void Move(float horizontal, float vertical)
    {
        DoMove(horizontal, vertical);
    }
}
