using UnityEngine;
using UnityEditor;
using UnityEditor.Compilation;
using System;

[ExecuteInEditMode]
public class CompilationTimer : MonoBehaviour
{
    private double compileStartTime;
    private bool isCompiling = false;

    private void OnEnable()
    {
        EditorApplication.update += EditorUpdate;
        CompilationPipeline.compilationStarted += CompilStarted;
    }

    private void OnDisable()
    {
        EditorApplication.update -= EditorUpdate;
        CompilationPipeline.compilationStarted -= CompilStarted;
    }


    private void EditorUpdate()
    {
        if(isCompiling)
        {
            if (!EditorApplication.isCompiling)
            {
                isCompiling = false;
                CompileFinished(null);
            }
        }
    }

    private void CompilStarted(object obj)
    {
        Debug.Log("Compile Started.");
        isCompiling = true;
        compileStartTime = EditorApplication.timeSinceStartup;
    }

    private void CompileFinished(object value)
    {
        double compileTime = EditorApplication.timeSinceStartup - compileStartTime;
        Debug.Log("Compile Finished: " + compileTime.ToString("F2") + "s");
    }
}
