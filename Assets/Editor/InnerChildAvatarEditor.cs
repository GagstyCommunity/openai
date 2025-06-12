using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InnerChildAvatar))]
public class InnerChildAvatarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        InnerChildAvatar avatar = (InnerChildAvatar)target;
        if (GUILayout.Button("Auto Assign Blendshapes"))
        {
            AutoAssign(avatar);
        }
    }

    private void AutoAssign(InnerChildAvatar avatar)
    {
        if (avatar.faceRenderer == null)
        {
            avatar.faceRenderer = avatar.GetComponentInChildren<SkinnedMeshRenderer>();
        }

        if (avatar.bodyAnimator == null)
        {
            avatar.bodyAnimator = avatar.GetComponentInChildren<Animator>();
        }

        if (avatar.faceRenderer != null)
        {
            var mesh = avatar.faceRenderer.sharedMesh;
            foreach (InnerChildAvatar.Emotion e in System.Enum.GetValues(typeof(InnerChildAvatar.Emotion)))
            {
                int index = mesh.GetBlendShapeIndex(e.ToString());
                if (index < 0)
                {
                    Debug.LogWarning($"Missing blendshape {e} on {mesh.name}", avatar.faceRenderer);
                }
            }
        }
        EditorUtility.SetDirty(avatar);
    }
}

