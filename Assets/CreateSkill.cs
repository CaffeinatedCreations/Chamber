using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 1)]
public class CreateSkill : ScriptableObject
{
    public Image icon;
    public string skillCategory, desc, skillName;
}
