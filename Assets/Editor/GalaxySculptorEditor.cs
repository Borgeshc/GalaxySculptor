using UnityEditor;
using UnityEngine;
 
 [CustomEditor(typeof(GalaxySculptor)), CanEditMultipleObjects]
public class GalaxySculptorEditor : Editor
{
    public SerializedProperty

        state_Prop,
        
        //Sun Properties
        Suns_Prop,
        sun_Prop,
        sunMinSize_Prop,
        sunMaxSize_Prop,
        sunsMinX_Prop,
        sunsMaxX_Prop,
        sunsMinY_Prop,
        sunsMaxY_Prop,
        sunsMinZ_Prop,
        sunsMaxZ_Prop,
        sunMinRotationSpeed_Prop,
        sunMaxRotationSpeed_Prop,

        //Planet Properties
        Planets_Prop,
        planets_Prop,
        planetSpeed_Prop,
        planetMinSize_Prop,
        planetMaxSize_Prop,
        planetsMinX_Prop,
        planetsMaxX_Prop,
        planetsMinY_Prop,
        planetsMaxY_Prop,
        planetsMinZ_Prop,
        planetsMaxZ_Prop,
        planetsMinRotationSpeed_Prop,
        planetsMaxRotationSpeed_Prop,

        //Moon Properties
        Moons_Prop,
        moons_Prop,
        moonSpeed_Prop,
        moonMinSize_Prop,
        moonMaxSize_Prop,
        moonsMinX_Prop,
        moonsMaxX_Prop,
        moonsMinY_Prop,
        moonsMaxY_Prop,
        moonsMinZ_Prop,
        moonsMaxZ_Prop,
        moonMinRotationSpeed_Prop,
        moonMaxRotationSpeed_Prop;
    void OnEnable()
    {
        // Setup the SerializedProperties
        state_Prop = serializedObject.FindProperty("state");

        //Find Sun Properties
        Suns_Prop = serializedObject.FindProperty("Suns");
        sun_Prop = serializedObject.FindProperty("sun");
        sunMinSize_Prop = serializedObject.FindProperty("sunMinSize");
        sunMaxSize_Prop = serializedObject.FindProperty("sunMaxSize");
        sunsMinX_Prop = serializedObject.FindProperty("sunsMinX");
        sunsMaxX_Prop = serializedObject.FindProperty("sunsMaxX");
        sunsMinY_Prop = serializedObject.FindProperty("sunsMinY");
        sunsMaxY_Prop = serializedObject.FindProperty("sunsMaxY");
        sunsMinZ_Prop = serializedObject.FindProperty("sunsMinZ");
        sunsMaxZ_Prop = serializedObject.FindProperty("sunsMaxZ");
        sunMinRotationSpeed_Prop = serializedObject.FindProperty("sunMinRotationSpeed");
        sunMaxRotationSpeed_Prop = serializedObject.FindProperty("sunMaxRotationSpeed");

        //Find Planet Properties
        Planets_Prop = serializedObject.FindProperty("Planets");
        planets_Prop = serializedObject.FindProperty("planets");
        planetSpeed_Prop = serializedObject.FindProperty("planetSpeed");
        planetMinSize_Prop = serializedObject.FindProperty("planetMinSize");
        planetMaxSize_Prop = serializedObject.FindProperty("planetMaxSize");
        planetsMinX_Prop = serializedObject.FindProperty("planetsMinX");
        planetsMaxX_Prop = serializedObject.FindProperty("planetsMaxX");
        planetsMinY_Prop = serializedObject.FindProperty("planetsMinY");
        planetsMaxY_Prop = serializedObject.FindProperty("planetsMaxY");
        planetsMinZ_Prop = serializedObject.FindProperty("planetsMinZ");
        planetsMaxZ_Prop = serializedObject.FindProperty("planetsMaxZ");
        planetsMinRotationSpeed_Prop = serializedObject.FindProperty("planetsMinRotationSpeed");
        planetsMaxRotationSpeed_Prop = serializedObject.FindProperty("planetsMaxRotationSpeed");

        //Find Moon Properties
        Moons_Prop = serializedObject.FindProperty("Moons");
        moons_Prop = serializedObject.FindProperty("moons");
        moonSpeed_Prop = serializedObject.FindProperty("moonSpeed");
        moonMinSize_Prop = serializedObject.FindProperty("moonMinSize");
        moonMaxSize_Prop = serializedObject.FindProperty("moonMaxSize");
        moonsMinX_Prop = serializedObject.FindProperty("moonsMinX");
        moonsMaxX_Prop = serializedObject.FindProperty("moonsMaxX");
        moonsMinY_Prop = serializedObject.FindProperty("moonsMinY");
        moonsMaxY_Prop = serializedObject.FindProperty("moonsMaxY");
        moonsMinZ_Prop = serializedObject.FindProperty("moonsMinZ");
        moonsMaxZ_Prop = serializedObject.FindProperty("moonsMaxZ");
        moonMinRotationSpeed_Prop = serializedObject.FindProperty("moonMinRotationSpeed");
        moonMaxRotationSpeed_Prop = serializedObject.FindProperty("moonMaxRotationSpeed");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();

        EditorGUILayout.PropertyField(state_Prop, new GUIContent("Object"));
        GalaxySculptor.Status st = (GalaxySculptor.Status)state_Prop.enumValueIndex;
        EditorGUIUtility.LookLikeInspector();
       
        switch (st)
        {
            case GalaxySculptor.Status.None:
                break;

            case GalaxySculptor.Status.Suns:
                EditorGUILayout.Slider(sunMinSize_Prop, 0, 1000, new GUIContent("Sun's Min Size"));
                EditorGUILayout.Slider(sunMaxSize_Prop, 0, 1000, new GUIContent("Sun's Max Size"));
                EditorGUILayout.Slider(sunsMinX_Prop, 0, 1000, new GUIContent("Sun's Min X Spawn"));
                EditorGUILayout.Slider(sunsMaxX_Prop, 0, 1000, new GUIContent("Sun's Max X Spawn"));
                EditorGUILayout.Slider(sunsMinY_Prop, 0, 1000, new GUIContent("Sun's Min Y Spawn"));
                EditorGUILayout.Slider(sunsMaxY_Prop, 0, 1000, new GUIContent("Sun's Max Y Spawn"));
                EditorGUILayout.Slider(sunsMinZ_Prop, 0, 1000, new GUIContent("Sun's Min Z Spawn"));
                EditorGUILayout.Slider(sunsMaxZ_Prop, 0, 1000, new GUIContent("Sun's Max Z Spawn"));
                EditorGUILayout.Slider(sunMinRotationSpeed_Prop, 0, 1000, new GUIContent("Sun's Min Rotation Speed"));
                EditorGUILayout.Slider(sunMaxRotationSpeed_Prop, 0, 1000, new GUIContent("Sun's Max Rotation Speed"));
                break;

            case GalaxySculptor.Status.Planets:
                EditorGUILayout.Slider(planetSpeed_Prop, 0, 1000, new GUIContent("Planet's Speed"));
                EditorGUILayout.Slider(planetMinSize_Prop, 0, 1000, new GUIContent("Planet's Min Size"));
                EditorGUILayout.Slider(planetMaxSize_Prop, 0, 1000, new GUIContent("Planet's Max Size"));
                EditorGUILayout.Slider(planetsMinX_Prop, 0, 1000, new GUIContent("Planet's Min X Spawn"));
                EditorGUILayout.Slider(planetsMaxX_Prop, 0, 1000, new GUIContent("Planet's Max X Spawn"));
                EditorGUILayout.Slider(planetsMinY_Prop, 0, 1000, new GUIContent("Planet's Min Y Spawn"));
                EditorGUILayout.Slider(planetsMaxY_Prop, 0, 1000, new GUIContent("Planet's Max Y Spawn"));
                EditorGUILayout.Slider(planetsMinZ_Prop, 0, 1000, new GUIContent("Planet's Min Z Spawn"));
                EditorGUILayout.Slider(planetsMaxZ_Prop, 0, 1000, new GUIContent("Planet's Max Z Spawn"));
                EditorGUILayout.Slider(planetsMinRotationSpeed_Prop, 0, 1000, new GUIContent("Planet's Min Rotation Speed"));
                EditorGUILayout.Slider(planetsMaxRotationSpeed_Prop, 0, 1000, new GUIContent("Planet's Max Rotation Speed"));
                break;

            case GalaxySculptor.Status.Moons:
                EditorGUILayout.Slider(moonSpeed_Prop, 0, 1000, new GUIContent("Moon's Speed"));
                EditorGUILayout.Slider(moonMinSize_Prop, 0, 1000, new GUIContent("Moon's Min Size"));
                EditorGUILayout.Slider(moonMaxSize_Prop, 0, 1000, new GUIContent("Moon's Max Size"));
                EditorGUILayout.Slider(moonsMinX_Prop, 0, 1000, new GUIContent("Moon's Min X Spawn"));
                EditorGUILayout.Slider(moonsMaxX_Prop, 0, 1000, new GUIContent("Moon's Max X Spawn"));
                EditorGUILayout.Slider(moonsMinY_Prop, 0, 1000, new GUIContent("Moon's Min Y Spawn"));
                EditorGUILayout.Slider(moonsMaxY_Prop, 0, 1000, new GUIContent("Moon's Max Y Spawn"));
                EditorGUILayout.Slider(moonsMinZ_Prop, 0, 1000, new GUIContent("Moon's Min Z Spawn"));
                EditorGUILayout.Slider(moonsMaxZ_Prop, 0, 1000, new GUIContent("Moon's Max Z Spawn"));
                EditorGUILayout.Slider(moonMinRotationSpeed_Prop, 0, 1000, new GUIContent("Moon's Min Rotation Speed"));
                EditorGUILayout.Slider(moonMaxRotationSpeed_Prop, 0, 1000, new GUIContent("Moon's Max Rotation Speed"));
                break;
        }
        serializedObject.ApplyModifiedProperties();
        EditorGUIUtility.LookLikeControls();
    }
}