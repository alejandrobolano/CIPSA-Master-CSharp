using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using CIPSA_CSharp_Module9WPF.Dao;
using CIPSA_CSharp_Module9WPF.Logicals;
using CIPSA_CSharp_Module9WPF.Logicals.Contract;
using CIPSA_CSharp_Module9WPF.Logicals.Model;

namespace CIPSA_CSharp_Module9WPF
{
    /// <summary>
    /// Interaction logic for School.xaml
    /// </summary>
    public partial class SchoolWindow : Window
    {
        private IXmlFile<Student> _studentXmlFile;
        private IXmlFile<Subject> _subjectXmlFile;
        
        private Student _studentSelected;
        private Subject _subjectSelected;
        public SchoolWindow()
        {
            InitializeComponent();
            InitializeStudentComponent();
            InitializeSubjectComponent();
        }

        private void InitializeStudentComponent()
        {
            StudentTab.Header = Utils.STUDENTTAB_HEADER;
            AddOrUpdateStudentButton.Content = Utils.ADD;
            AddNoteExamCheckBox.Content = Utils.ADD;
            NewStudentButton.Content = Utils.NEW;
            NewStudentButton.Visibility = Visibility.Hidden;
            _studentXmlFile = new StudentXmlFile();
        }
        private void InitializeSubjectComponent()
        {
            SubjectTab.Header = Utils.SUBJECTTAB_HEADER;
            AddOrUpdateSubjectButton.Content = Utils.ADD;
            NewSubjectButton.Content = Utils.NEW;
            NewSubjectButton.Visibility = Visibility.Hidden;
            _subjectXmlFile = new SubjectXmlFile();
            AreaComboBox.ItemsSource = new List<string>()
            {
                Utils.SELECT,
                AreasHighSchool.Artes.ToString(),
                AreasHighSchool.Ciencias.ToString(),
                AreasHighSchool.Humanidades.ToString()
            };
        }

        #region Common
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Utils.HasNotNumberValidation(e.Text);
        }
        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Utils.HasNotTextValidation(e.Text);
        }
        private void LoadGrid(DataGrid grid)
        {
            if (((TabItem)SchoolTabControl.SelectedItem).Header.ToString().Equals(Utils.STUDENTTAB_HEADER))
            {
                grid.ItemsSource = _studentXmlFile.GetAll();
            }
            if (((TabItem)SchoolTabControl.SelectedItem).Header.ToString().Equals(Utils.SUBJECTTAB_HEADER))
            {
                grid.ItemsSource = _subjectXmlFile.GetAll();
            }

        }
        private void UpdateDataGridAndClearFields(DataGrid dataGridToLoad, Grid gridToClear)
        {
            LoadGrid(dataGridToLoad);
            Utils.ClearFields(gridToClear);
        }

        #endregion


        #region Student
        private void AddOrUpdateStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var hasAnyEmptyFields = Utils.HasAnyEmptyFields(StudentGrid);
            var male = MaleRadioButton?.IsChecked != null && (bool)MaleRadioButton?.IsChecked;
            var female = FemaleRadioButton?.IsChecked != null && (bool)FemaleRadioButton?.IsChecked;
            var hasAnySelectedChecks = (male || female);

            if (!hasAnyEmptyFields && hasAnySelectedChecks)
            {
                var name = NameTextBox.Text;
                var lastName = LastNameTextBox.Text;
                var age = Convert.ToInt32(AgeTextBox.Text);
                var sex = Convert.ToChar(male ? MaleRadioButton.Content.ToString() : FemaleRadioButton.Content.ToString());
                var examNote = 0;
                if (AddNoteExamCheckBox.IsChecked != null && (bool)AddNoteExamCheckBox.IsChecked)
                {
                    var note = ExamNoteTextBox.Text;
                    examNote = note.Equals(string.Empty) ? 0 : Convert.ToInt32(note);
                }

                if (AddOrUpdateStudentButton.Content.Equals(Utils.ADD))
                {
                    var student = new Student(name, lastName, sex, age, examNote);
                    _studentXmlFile.Add(student);
                    UpdateStudentDataGrid();
                }
                else
                {
                    _studentSelected.Name = name;
                    _studentSelected.LastName = lastName;
                    _studentSelected.Age = age;
                    _studentSelected.Sex = sex;
                    _studentSelected.ExamNote = examNote;
                    _studentXmlFile.Update(_studentSelected);
                    UpdateStudentDataGrid();
                }

            }
            else
            {
                Utils.ShowMessageByEmptyFields();
            }
        }

        private void UpdateStudentDataGrid()
        {
            UpdateDataGridAndClearFields(StudentDataGrid, StudentGrid);
            NewStudentButton.Visibility = Visibility.Hidden;
            AddOrUpdateStudentButton.Content = Utils.ADD;
        }

        private void StudentDataGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is DataGrid grid)
                LoadGrid(grid);
        }

        private void AddNoteExamCheckBox_CheckChange(object sender, RoutedEventArgs e)
        {
            var isChecked = ((CheckBox)sender).IsChecked;
            if (isChecked != null) ExamNoteTextBox.IsEnabled = (bool)isChecked;
        }

        private void StudentDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rowSelectedValue = sender as DataGrid;
            _studentSelected = (Student)rowSelectedValue?.SelectedValue;
            if (_studentSelected != null)
            {
                NameTextBox.Text = _studentSelected.Name;
                LastNameTextBox.Text = _studentSelected.LastName;
                AgeTextBox.Text = _studentSelected.Age.ToString();
                if (_studentSelected.Sex == 'H')
                    MaleRadioButton.IsChecked = true;
                else
                {
                    FemaleRadioButton.IsChecked = true;
                }

                ExamNoteTextBox.Text = _studentSelected.ExamNote.ToString();
            }

            AddNoteExamCheckBox.IsChecked = true;
            NewStudentButton.Visibility = Visibility.Visible;
            AddOrUpdateStudentButton.Content = Utils.UPDATE;
            AddNoteExamCheckBox.Content = Utils.UPDATE;
        }

        private void NewStudentButton_Click(object sender, RoutedEventArgs e)
        {
            //var foo = (SchoolTabControl.SelectedItem as TabItem).Header.ToString();
            Utils.ClearFields(StudentGrid);
            AddOrUpdateStudentButton.Content = Utils.ADD;
            AddNoteExamCheckBox.Content = Utils.ADD;
            NewStudentButton.Visibility = Visibility.Hidden;
        }
        private void ExamNoteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var value = ((TextBox)sender).Text;
            int.TryParse(value, out var examResult);
            if (examResult > 10)
            {
                ((TextBox)sender).Text = string.Empty;
                MessageBox.Show("La nota debe estar comprendida entre 1 al 10", "Información");
            }

        }

        private void AssignSubjectButton_OnClick(object sender, RoutedEventArgs e)
        {
            var studentContext = (Student)((Button)e.Source).DataContext;

            var assignWindow = new AssignSubjectToStudent(studentContext.Id);
            assignWindow.Show();
        }

        #endregion

        #region Subject

        private void SubjectDataGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is DataGrid grid) LoadGrid(grid);
        }

        private void AddOrUpdateSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            var hasAnyEmptyFields = Utils.HasAnyEmptyFields(SubjectGrid);

            if (!hasAnyEmptyFields)
            {
                var name = NameSubjectTextBox.Text;
                var area = AreaComboBox.Text;

                if (AddOrUpdateSubjectButton.Content.Equals(Utils.ADD))
                {
                    var subject = new Subject(name, area);
                    _subjectXmlFile.Add(subject);
                    UpdateSubjectDataGrid();
                }
                else
                {
                    _subjectSelected.Name = name;
                    _subjectSelected.Area = area;
                    _subjectXmlFile.Update(_subjectSelected);
                    UpdateSubjectDataGrid();
                }

            }
            else
            {
                Utils.ShowMessageByEmptyFields();
            }
        }

        private void UpdateSubjectDataGrid()
        {
            UpdateDataGridAndClearFields(SubjectDataGrid, SubjectGrid);
            NewSubjectButton.Visibility = Visibility.Hidden;
            AddOrUpdateSubjectButton.Content = Utils.ADD;
        }

        private void SubjectDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rowSelectedValue = sender as DataGrid;
            _subjectSelected = (Subject)rowSelectedValue?.SelectedValue;
            if (_subjectSelected != null)
            {
                NameSubjectTextBox.Text = _subjectSelected.Name;
                AreaComboBox.SelectedItem = _subjectSelected.Area;
            }
            NewSubjectButton.Visibility = Visibility.Visible;
            AddOrUpdateSubjectButton.Content = Utils.UPDATE;
        }
        
        private void NewSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            Utils.ClearFields(SubjectGrid);
            AddOrUpdateSubjectButton.Content = Utils.ADD;
            NewSubjectButton.Visibility = Visibility.Hidden;
        }

        #endregion

    }
}
