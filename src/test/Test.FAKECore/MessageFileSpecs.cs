using System;
using System.Linq;
using Fake;
using Machine.Specifications;

namespace Test.FAKECore.XMLHandling
{
    public class when_reading_the_message_file
    {
        static string _text;

        Because of = () => _text = StringHelper.ReadFileAsString("./MessageFiles/Message1.txt");

        It should_not_be_empty = () => _text.ShouldNotBeEmpty();
    }

    public class when_getting_the_test_suite
    {
        static DynamicsNav.TestResults _result;

        Because of = () => _result = DynamicsNav.analyzeTestResults("./MessageFiles/Message1.txt");

        It should_find_the_test_suite = () => _result.SuiteName.ShouldEqual("Test Math");
        It should_find_all_tests = () => _result.Tests.Count().ShouldEqual(14);
    }

    public class when_getting_the_test_names
    {
        static DynamicsNav.TestResults _result;

        Because of = () => _result = DynamicsNav.analyzeTestResults("./MessageFiles/Message1.txt");

        It should_find_the_first_test = () => _result.Tests[0].Name.ShouldEqual("TestGCD");
        It should_find_the_second_test = () => _result.Tests[1].Name.ShouldEqual("TestLCM");
        It should_find_the_last_test = () => _result.Tests.Last().Name.ShouldEqual("TestAddFractions2");
    }

    public class when_getting_the_test_runtimes
    {
        static DynamicsNav.TestResults _result;

        Because of = () => _result = DynamicsNav.analyzeTestResults("./MessageFiles/Message1.txt");

        It should_find_the_first_test = () => _result.Tests[0].RunTime.ShouldEqual(TimeSpan.FromMilliseconds(218));
        It should_find_the_second_test = () => _result.Tests[1].RunTime.ShouldEqual(TimeSpan.FromMilliseconds(8));
        It should_find_the_last_test = () => _result.Tests.Last().RunTime.ShouldEqual(TimeSpan.FromMilliseconds(11));
    }
}