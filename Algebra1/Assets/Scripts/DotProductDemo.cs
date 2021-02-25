using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DotProductDemo : MonoBehaviour
{

    public enum StaticRay_Direction
    {
        Left,
        Up,
        Right,
        Down
    }

    public bool RenderRay_StaticRay = false;

    public StaticRay_Direction StaticRayDirection = StaticRay_Direction.Right;

    public bool RenderRay_ToMouse = false;

    public bool RenderRay_ToMouseNormalized = false;

    public bool RenderDot = false;

    public bool RenderDot_IntersectingLine = false;

    public bool RenderAngle = false;

    public float Magnitude = 0f;

    public float Dot = 0f;

    public float Angle = 0.0f;

    public Camera Cam = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        #region Static Ray

        Vector2 StaticRay = Vector2.right;

        switch(StaticRayDirection)
        {
            case StaticRay_Direction.Up:
                StaticRay = Vector2.up;
                break;
            case StaticRay_Direction.Down:
                StaticRay = Vector2.down;
                break;
            case StaticRay_Direction.Left:
                StaticRay = Vector2.left;
                break;
            case StaticRay_Direction.Right:
            default:
                StaticRay = Vector2.right;
                break;
        }

        if(RenderRay_StaticRay)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Vector2.zero, StaticRay);
        }

        #endregion

        if (Cam)
        {
            #region Mouse To World Position

            Vector2 MousePosition = Event.current.mousePosition;
            float pixelPerPoint = EditorGUIUtility.pixelsPerPoint;
            MousePosition.y = SceneView.lastActiveSceneView.camera.pixelHeight - MousePosition.y * pixelPerPoint;
            MousePosition.x *= pixelPerPoint;
            Vector2 MouseWorldPosition = SceneView.lastActiveSceneView.camera.ScreenToWorldPoint(MousePosition);

            Vector2 HalfWorldPosition = MouseWorldPosition * 0.5f;

            Vector2 MouseOffset = Event.current.mousePosition + new Vector2(12, 12);
            MouseOffset.y = SceneView.lastActiveSceneView.camera.pixelHeight - MouseOffset.y * pixelPerPoint;
            MouseOffset.x *= pixelPerPoint;
            Vector2 MouseOffsetWorld = SceneView.lastActiveSceneView.camera.ScreenToWorldPoint(MouseOffset);

            #endregion

            #region Render Ray
            Vector2 MouseWorldRay = MouseWorldPosition - Vector2.zero;

            Magnitude = MouseWorldRay.magnitude;

            if(RenderRay_ToMouse)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(Vector2.zero, MouseWorldRay);
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.green;

                Handles.Label(MouseOffsetWorld,"(x:"+MouseWorldPosition.x.ToString("0.0000")+",y : "+MouseWorldPosition.y.ToString("0.0000")+")",style);

                Handles.Label(HalfWorldPosition, "Length:" + MouseWorldRay.magnitude.ToString("0.0000"), style);
            }
            #endregion



            #region Render Ray - Normalized

            if(RenderRay_ToMouseNormalized)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(Vector2.zero, MouseWorldRay.normalized);
            }

            #endregion


            #region Dot Product


            //Calcular el producto punto entre la posicion del mouse en lainterfaz d eunity y el gizmo statico (Arriba,Abajo,Derecha o Izquierda)
            //ambos vectores deben estar normalizados
            Dot = Vector2.Dot(MouseWorldRay.normalized, StaticRay.normalized);

            if(RenderDot)
            {
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.blue;
                Handles.Label(Vector2.zero, "Dot Product: " + Dot.ToString("0.0000"), style);
            }

            #endregion


            #region Dot Product - Intersecting Line

            if (RenderDot_IntersectingLine)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawLine(new Vector2(Dot, 1f), new Vector2(Dot, -1f));

                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.white;
                Handles.Label(new Vector2(Dot, -1f), "Dot x:" + Dot.ToString("0.00"), style);
            }



            #endregion


            #region Angle

            if (RenderAngle)
            {
                //Obtener el arco coseno del producto punto, posteriormente convertir de radianes a grados
                Angle = Mathf.Acos(Dot) * Mathf.Rad2Deg;

                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.red;
                Handles.Label(Vector2.zero, "Angles: " + Angle.ToString("0.0000"), style);
            }

            #endregion
        }


        //if (Cam)
        //{
        //    #region Mouse To World Position

        //    Vector2 MousePos = Event.current.mousePosition;
        //    float ppp = EditorGUIUtility.pixelsPerPoint;
        //    MousePos.y = SceneView.lastActiveSceneView.camera.pixelHeight - MousePos.y * ppp;
        //    MousePos.x *= ppp;

        //    Vector2 MouseWorldPos = SceneView.lastActiveSceneView.camera.ScreenToWorldPoint(MousePos);

        //    Vector2 HalfWorldPos = MouseWorldPos * 0.5f;

        //    Vector2 mouseOffset = Event.current.mousePosition + new Vector2(12, 12);
        //    mouseOffset.y = SceneView.lastActiveSceneView.camera.pixelHeight - mouseOffset.y * ppp;
        //    mouseOffset.x *= ppp;
        //    Vector2 mouseOffsetWorld = SceneView.lastActiveSceneView.camera.ScreenToWorldPoint(mouseOffset);

        //    #endregion


        //    #region Render Ray

        //    Vector2 MouseWorldRay = MouseWorldPos - Vector2.zero;

        //    Magnitude = MouseWorldRay.magnitude;

        //    if (RenderRay_ToMouse)
        //    {
        //        Gizmos.color = Color.blue;
        //        Gizmos.DrawRay(Vector2.zero, MouseWorldRay);
        //        GUIStyle style = new GUIStyle();
        //        style.normal.textColor = Color.blue;
        //        Handles.Label(mouseOffsetWorld, "(x:" + MouseWorldPos.x.ToString("0.000") + ",y:" + MouseWorldPos.y.ToString("0.000") + ")", style);

        //        Handles.Label(HalfWorldPos, "Length:" + MouseWorldRay.magnitude.ToString("0.000"), style);
        //    }

        //    #endregion


        //    #region Render Ray - Normalized

        //    if (RenderRay_ToMouseNormalized)
        //    {
        //        Gizmos.color = new Color(0.5f, 0.5f, 1f, 1f);
        //        Gizmos.DrawRay(Vector2.zero, MouseWorldRay.normalized);
        //    }

        //    #endregion


        //    #region Dot Product

        //    //Calculate the dot product of the MouseWorldRay vs the static ray - both rays must be normalized!
        //    Dot = Vector2.Dot(MouseWorldRay.normalized, StaticRay.normalized);

        //    if (RenderDot)
        //    {
        //        GUIStyle style = new GUIStyle();
        //        style.normal.textColor = Color.white;
        //        Handles.Label(Vector2.zero, "Dot Product:" + Dot.ToString("0.00"), style);
        //    }

        //    #endregion


        //    #region Dot Product - Intersecting Line

        //    if (RenderDot_IntersectingLine)
        //    {
        //        Gizmos.color = Color.white;
        //        Gizmos.DrawLine(new Vector2(Dot, 1f), new Vector2(Dot, -1f));

        //        GUIStyle style = new GUIStyle();
        //        style.normal.textColor = Color.white;
        //        Handles.Label(new Vector2(Dot, -1f), "Dot x:" + Dot.ToString("0.00"), style);
        //    }

        //    #endregion


        //    #region Angle

        //    if (RenderAngle)
        //    {
        //        //Get the Arc Cosine of the Dot Product, then convert it from radians to degrees.
        //        float Angle = Mathf.Acos(Dot) * Mathf.Rad2Deg;

        //        GUIStyle style = new GUIStyle();
        //        style.normal.textColor = Color.yellow;
        //        Handles.Label(new Vector2(0f, -0.05f), "Angle:" + Angle.ToString("0.00") + " Degrees", style);
        //    }

        //    #endregion
        //}

    }
}
