using oop_4.StressTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace oop_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Array materialItems = Enum.GetValues(typeof(Material));
            Array crossSectionItems = Enum.GetValues(typeof(CrossSection));
            Array testResultItems = Enum.GetValues(typeof(TestResult));

            foreach (var material in materialItems)
                materials.Items.Add(material);
            foreach (var crossSection in crossSectionItems)
                crossSections.Items.Add(crossSection);
            foreach (var testRusult in testResultItems)
                testResults.Items.Add(testRusult);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = new StringBuilder();

            Material selectedMaterial = (Material)materials.SelectedItem;
            selection.Append($"Material: {selectedMaterial}\n");

            if (crossSections.SelectedItem != null)
            {
                CrossSection selectedSection = (CrossSection)crossSections.SelectedItem;
                selection.Append($"Cross-section: {selectedSection}\n");
            }

            if (testResults.SelectedItem != null)
            {
                TestResult selectedResult = (TestResult)testResults.SelectedItem;
                selection.Append($"Result: {selectedResult}\n");
            }

            result.Content = selection.ToString();
        }

        private void runTests_Click(object sender, RoutedEventArgs e)
        {
            reasonsList.Items.Clear();
            TestCaseResult[] testCaseResults = new TestCaseResult[10];
            var success = 0;
            var fail = 0;
            for (var i = 0; i < testCaseResults.Length; i++)
            {
                testCaseResults[i] = TestManager.GenerateResult();
                if (testCaseResults[i].Result == TestResult.Fail)
                {
                    fail++;
                    reasonsList.Items.Add("Тест №" + (i + 1) + " завершился с ошибкой: " + testCaseResults[i].ReasonForFailure);
                }
                else
                {
                    success++;
                }
            }
            successTests.Content = "Пройдено тестов: " + success;
            failTests.Content = "Провалено тестов: " + fail;
        }
    }
}
