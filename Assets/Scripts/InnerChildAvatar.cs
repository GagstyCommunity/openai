using UnityEngine;

/// <summary>
/// Controls avatar facial blendshapes and body animations to reflect simple emotions.
/// </summary>
public class InnerChildAvatar : MonoBehaviour
{
    public enum Emotion
    {
        Happy,
        Sad,
        Angry,
        Calm
    }

    [Tooltip("SkinnedMeshRenderer with blendshapes for facial expressions")] 
    public SkinnedMeshRenderer faceRenderer;

    [Tooltip("Animator controlling body animations")] 
    public Animator bodyAnimator;

    [Range(0f, 100f)]
    public float blendWeight = 100f;

    [Tooltip("Optional variable that drives the avatar's emotion")] 
    public EmotionVariable emotionVariable;

    private Emotion currentEmotion = Emotion.Calm;

    public Emotion CurrentEmotion => currentEmotion;

    /// <summary>
    /// Initializes the avatar by applying the current emotion state.
    /// </summary>
    void Start()
    {
        UpdateExpression();
    }

    /// <summary>
    /// Updates the avatar each frame, synchronizing with the optional EmotionVariable.
    /// </summary>
    void Update()
    {
        if (emotionVariable != null && emotionVariable.Value != currentEmotion)
        {
            SetEmotion(emotionVariable.Value);
        }
#if UNITY_EDITOR
        DevKeyboardTest();
#endif
    }

    /// <summary>
    /// Changes the current emotion and refreshes blendshapes and animations.
    /// </summary>
    /// <param name="emotion">The emotion to switch to.</param>
    public void SetEmotion(Emotion emotion)
    {
        currentEmotion = emotion;
        UpdateExpression();
    }

    /// <summary>
    /// Applies the current emotion to all renderers and animators.
    /// </summary>
    private void UpdateExpression()
    {
        if (faceRenderer != null)
        {
            ResetBlendshapes();
            int index = faceRenderer.sharedMesh.GetBlendShapeIndex(currentEmotion.ToString());
            if (index >= 0)
            {
                faceRenderer.SetBlendShapeWeight(index, blendWeight);
            }
        }

        if (bodyAnimator != null)
        {
            bodyAnimator.Play(currentEmotion.ToString());
        }
    }

    /// <summary>
    /// Clears all blendshape weights on the face mesh.
    /// </summary>
    private void ResetBlendshapes()
    {
        if (faceRenderer == null || faceRenderer.sharedMesh == null)
            return;

        for (int i = 0; i < faceRenderer.sharedMesh.blendShapeCount; i++)
        {
            faceRenderer.SetBlendShapeWeight(i, 0f);
        }
    }

#if UNITY_EDITOR
    /// <summary>
    /// Allows quick testing of emotions in Play mode using number keys.
    /// 1=Happy, 2=Sad, 3=Angry, 4=Calm.
    /// </summary>
    private void DevKeyboardTest()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetEmotion(Emotion.Happy);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetEmotion(Emotion.Sad);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetEmotion(Emotion.Angry);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SetEmotion(Emotion.Calm);
    }
#endif
}

