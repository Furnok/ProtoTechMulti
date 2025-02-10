using NUnit.Framework;
using System.Reflection;
using System;
using UnityEngine;

public static class TestUtils
{
    public static T InjectRSO<T>(object target, string fieldName, T value) where T : class
    {
        Type type = target.GetType();
        BindingFlags flags = BindingFlags.NonPublic | BindingFlags.SetField | BindingFlags.Instance | BindingFlags.SetProperty;

        FieldInfo fieldInfo = type.GetField(fieldName, flags);

        if (fieldInfo == null)
            throw new Exception($"Field '{fieldName}' not found on type {type.Name}");

        // Ensure value is of correct type
        if (!(value is T))
            throw new ArgumentException($"Value is not of type {typeof(T).Name}");

        // Set the value to the provided instance
        fieldInfo.SetValue(target, value);

        // Return the updated field value
        return fieldInfo.GetValue(target) as T;
    }
}

public class DirectionTests
{
    [Test]
    public void Should_add_score_when_goal()
    {
        S_GameManager gameManager = new S_GameManager();

        RSO_CurrentScore rsoCurrentScore = ScriptableObject.CreateInstance<RSO_CurrentScore>();
        rsoCurrentScore.Value = 0;

        TestUtils.InjectRSO(gameManager, "rsoCurrentScoreP1", rsoCurrentScore);

        gameManager.Goal(1);

        Assert.AreEqual(1, rsoCurrentScore.Value);
    }
}
