using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ShooterClump))]
[CanEditMultipleObjects]
public class ShooterClumpEditor : Editor
{
    SerializedProperty _partToRotate;
    SerializedProperty _bullet;
    SerializedProperty _player;
    SerializedProperty _firepoint;
    SerializedProperty _turnSpeed;
    SerializedProperty _waitTime;
    SerializedProperty _bulletAmount;
    SerializedProperty _clumpWaitTime;
    SerializedProperty _bulletSpeed;
    SerializedProperty _shooting;
    SerializedProperty _explosionWaitTime;
    SerializedProperty _explosionRadius;
    SerializedProperty _explodeOnDestroy;
    SerializedProperty _explosionTime;
    SerializedProperty _explosionMaterial;
    SerializedProperty _direction;
    

    public bool shooting = true;
    
    void OnEnable()
    {
        _partToRotate = serializedObject.FindProperty("partToRotate");
        _bullet = serializedObject.FindProperty("bullet");
        _player = serializedObject.FindProperty("player");
        _firepoint = serializedObject.FindProperty("firepoint");
        _turnSpeed = serializedObject.FindProperty("turnSpeed");
        _waitTime = serializedObject.FindProperty("waitTime");
        _bulletAmount = serializedObject.FindProperty("bulletAmount");
        _clumpWaitTime = serializedObject.FindProperty("clumpWaitTime");
        _bulletSpeed = serializedObject.FindProperty("bulletSpeed");
        _shooting = serializedObject.FindProperty("shooting");
        _explosionWaitTime = serializedObject.FindProperty("explosionWaitTime");
        _explosionRadius = serializedObject.FindProperty("explosionRadius");
        _explodeOnDestroy = serializedObject.FindProperty("explodeOnDestroy");
        _explosionTime = serializedObject.FindProperty("explosionTime");
        _explosionMaterial = serializedObject.FindProperty("explosionMaterial");
        _direction = serializedObject.FindProperty("direction");

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
        EditorGUILayout.PropertyField(_bulletAmount);
        EditorGUILayout.PropertyField(_clumpWaitTime);
        EditorGUILayout.PropertyField(_bulletSpeed);
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

        serializedObject.ApplyModifiedProperties();
    }
}
