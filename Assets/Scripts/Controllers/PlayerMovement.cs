using UnityEngine;
using NaughtyAttributes;
using TNRD;
using UnityEngine.Events;

public class PlayerMovement : Movement
{
    public void Move(float horizontal, float vertical)
    {
        DoMove(horizontal, vertical);
    }
}
