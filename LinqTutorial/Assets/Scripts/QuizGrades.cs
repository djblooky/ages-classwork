using System.Linq;
using UnityEngine;

public class QuizGrades : MonoBehaviour
{
    private int[] quizGrades = { 35, 99, 100, 45, 67, 80, 89, 78 };

    private void Start()
    {
        var passingGrades = quizGrades.Where(qg => qg > 69) //saves all passing grades into a collection 
            .OrderByDescending(g => g).Reverse(); //orders the list by ascending 

        Debug.Log("Passing grades:");
        foreach (var grade in passingGrades)
        {
            Debug.Log(grade);
        }
    }
}
