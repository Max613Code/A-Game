using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Shooter))]
[CanEditMultipleObjects]
public class ShooterEditor : Editor
{
    SerializedProperty _partToRotate;
    SerializedProperty _bullet;
    SerializedProperty _player;
    SerializedProperty _firepoint;
    SerializedProperty _turnSpeed;
    SerializedProperty _waitTime;
    SerializedProperty _bulletSpeed;
    SerializedProperty _bulletSize;
    SerializedProperty _shooting;
    
    SerializedProperty _explosionWaitTime;
    SerializedProperty _explosionRadius;
    SerializedProperty _explodeOnDestroy;
    SerializedProperty _explosionTime;
    SerializedProperty _explosionMaterial;
    SerializedProperty _direction;
    
    SerializedProperty _homing;
    SerializedProperty _bulletTurnSpeed;
    private SerializedProperty _homingDestroyTime;
    

    public bool shooting = true;
    
    void OnEnable()
    {
        _partToRotate = serializedObject.FindProperty("partToRotate");
        _bullet = serializedObject.FindProperty("bullet");
        _player = serializedObject.FindProperty("player");
        _firepoint = serializedObject.FindProperty("firepoint");
        _turnSpeed = serializedObject.FindProperty("turnSpeed");
        _waitTime = serializedObject.FindProperty("waitTime");
        _bulletSpeed = serializedObject.FindProperty("bulletSpeed");
        _bulletSize = serializedObject.FindProperty("bulletSize");
        _shooting = serializedObject.FindProperty("shooting");
        
        _explosionWaitTime = serializedObject.FindProperty("explosionWaitTime");
        _explosionRadius = serializedObject.FindProperty("explosionRadius");
        _explodeOnDestroy = serializedObject.FindProperty("explodeOnDestroy");
        _explosionTime = serializedObject.FindProperty("explosionTime");
        _explosionMaterial = serializedObject.FindProperty("explosionMaterial");
        _direction = serializedObject.FindProperty("direction");

        _homing = serializedObject.FindProperty("homing");
        _bulletTurnSpeed = serializedObject.FindProperty("bulletTurnSpeed");
        _homingDestroyTime = serializedObject.FindProperty("homingDestroyTime");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_partToRotate);
        EditorGUILayout.PropertyField(_bullet);
        EditorGUILayout.PropertyField(_player);
        EditorGUILayout.PropertyField(_firepoint);
        EditorGUILayout.PropertyField(_turnSpeed);
        EditorGUILayout.PropertyField(_waitTime);
        EditorGUILayout.PropertyField(_bulletSpeed);
        EditorGUILayout.PropertyField(_bulletSize);
        EditorGUILayout.PropertyField(_shooting);

        if (_bullet.objectReferenceValue.name == "BulletExplosion")
        {
            EditorGUILayout.PropertyField(_explosionWaitTime);
            EditorGUILayout.PropertyField(_explosionRadius);
            EditorGUILayout.PropertyField(_explodeOnDestroy);
            EditorGUILayout.PropertyField(_explosionTime);
            EditorGUILayout.PropertyField(_explosionMaterial);
            EditorGUILayout.PropertyField(_direction);
        }

        EditorGUILayout.PropertyField(_homing);

        if (_homing.boolValue)
        {
            EditorGUILayout.PropertyField(_bulletTurnSpeed);
            EditorGUILayout.PropertyField(_homingDestroyTime);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
