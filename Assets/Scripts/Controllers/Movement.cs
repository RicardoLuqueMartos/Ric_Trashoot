using System;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour, IMove
{
    #region Variables
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb2d;

    [Header("Parameters")]
    [SerializeField] private float _moveSpeed = 10f;
    public float m_rotateSpeed = 50f;

    private float _horizontal;
    private float _vertical;
    #endregion Variables

    public void Initialize(Rigidbody2D rb2d)
    {
        _rb2d = rb2d;
    }

    /// <summary>
    /// Moves the entity in a direction.
    /// </summary>
    /// <param name="direction">The direction to move the player in.</param>
    public void DoMove(float horizontal, float vertical)
    {
        if (Math.Abs(horizontal) < 0.01f
            && Math.Abs(horizontal) > -0.01f)
        {
            _horizontal = 0f;
            _rb2d.velocity = new Vector2(_horizontal, _rb2d.velocity.y);
        }
        else
        {
            _horizontal = horizontal;

        }
        if (Math.Abs(vertical) < 0.01f
            && Math.Abs(vertical) > -0.01f)
        {
            _vertical = 0f;
        }
        else
        {
            _vertical = vertical;
        }
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = _rb2d.transform.up * (_vertical * _moveSpeed);
     
        if (_horizontal != 0)       
            _rb2d.transform.Rotate(0, 0, -_horizontal * m_rotateSpeed * Time.deltaTime);
    }
}
