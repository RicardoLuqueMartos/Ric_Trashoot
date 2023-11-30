using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntityData : ObjectData
{
    #region Variables
    [Header("Entity")]
    [SerializeField]
    protected int m_Health;

    [SerializeField]
    protected float m_MoveSpeed;

    #endregion Variables
}
