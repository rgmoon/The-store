using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(視野觸發))]
public class FOVEDITOR : Editor
{
    private void GUI()
    {
        視野觸發 fov = (視野觸發)target;
        Handles.color=Color.white;
        Handles.DrawWireArc(fov.transform.position,Vector3.up,Vector3.forward,360,fov.radius);  
    }

}
