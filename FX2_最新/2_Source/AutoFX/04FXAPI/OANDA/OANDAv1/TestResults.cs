using System;
using System.Collections.Generic;

namespace OANDAv1
{
    public class TestResult
    {
        public bool Success { get; set; }
        public string Details { get; set; }
    }

    class TestResults
    {
        List<TestResult> _results = new List<TestResult>();

        public void Add(TestResult testResult)
        {
            _results.Add(testResult);
        }

        public bool Verify(string success, string testDescription)
        {
            return Verify(!string.IsNullOrEmpty(success), testDescription);
        }

        public bool Verify(bool success, string testDescription)
        {
            _results.Add(new TestResult { Success = success, Details = testDescription });
            if (!success)
            {
                Console.WriteLine(success + ": " + testDescription);
            }
            return success;
        }
    }
}
