using UnityEngine;

[CreateAssetMenu(menuName = "InnerChild/Emotion Variable")]
public class EmotionVariable : ScriptableObject
{
    public InnerChildAvatar.Emotion Value = InnerChildAvatar.Emotion.Calm;
}

