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
using System.Windows.Shapes;
using CIPSA_CSharp_Module9WPF.Dao;
using CIPSA_CSharp_Module9WPF.Logicals.Contract;
using CIPSA_CSharp_Module9WPF.Logicals.Model;

namespace CIPSA_CSharp_Module9WPF
{
    /// <summary>
    /// Interaction logic for AssignSubjectToStudent.xaml
    /// </summary>
    public partial class AssignSubjectToStudent : Window
    {
        private readonly IXmlFile<Subject> _subjectXmlFile;
        private readonly IXmlFile<Student> _studentXmlFile;
        private readonly IStudentSubjectXmlFile _studentSubjectXmlFile;
        private List<Subject> subjectsOfStudentList;
        private List<Subject> originalSubjectsOfStudentList;
        private Subject _subjectSelected;

        private readonly Guid _studentId;
        //public Guid studentId { get; set; }
        public AssignSubjectToStudent(Guid studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            _subjectXmlFile = new SubjectXmlFile();
            _studentXmlFile = new StudentXmlFile();
            _studentSubjectXmlFile = new StudentSubjectXmlFile();

            LoadListBox();
            
            SubjectsComboBox.ItemsSource = _subjectXmlFile.GetAll();
            var student = _studentXmlFile.Get(studentId);
            FullNameStudentLabel.Content = $"Puede asignar nuevas asignaturas para el " +
                                           $"estudiante : \n {student.Name.ToUpper()} {student.LastName.ToUpper()}";
        }

        private void LoadListBox()
        {
            var studentSubjects = _studentSubjectXmlFile.GetAllByStudent(_studentId);
            subjectsOfStudentList = new List<Subject>();
            originalSubjectsOfStudentList = new List<Subject>();
            foreach (var subject in studentSubjects)
            {
                subjectsOfStudentList.Add(_subjectXmlFile.Get(subject.SubjectId));
                originalSubjectsOfStudentList.Add(_subjectXmlFile.Get(subject.SubjectId));
            }
            SubjectAssignListBox.ItemsSource = subjectsOfStudentList;
        }

        private void AddSubjectToStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var subject = (Subject) SubjectsComboBox.SelectedValue;
            var iterator = 0;
            var isExistInListBox = false;
            var subjectsInListBox = SubjectAssignListBox.Items;
            while (!isExistInListBox && iterator < subjectsInListBox.Count)
            {
                if (((Subject)subjectsInListBox[iterator]).Equals(subject))
                {
                    isExistInListBox = true;
                }

                iterator++;
            }

            if (!isExistInListBox)
            {
                subjectsOfStudentList.Add(subject);
            }
            SubjectAssignListBox.Items.Refresh();
            
        }

        private void SubjectAssignListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _subjectSelected = (Subject) ((ListBox) sender).SelectedValue;
            if (_subjectSelected != null)
            {
                SubjectsComboBox.SelectedItem = _subjectSelected;
                InfoSubjectLabel.Content = $"Area: {_subjectSelected.Area} - {_subjectSelected.Name}";
            }
            //NewSubjectButton.Visibility = Visibility.Visible;
            AddOrUpdateSubjectToStudentButton.Content = Utils.UPDATE;
        }

        private void AddAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var subject in SubjectAssignListBox.Items)
            {
                var studentSubject = new StudentSubject(_studentId,((Subject)subject).Id);
                if (!HasNotExist((Subject)subject))
                {
                    _studentSubjectXmlFile.Add(studentSubject);
                }
            }
            Close();
        }

        private bool HasNotExist(Subject subject)
        {
            var hasExist = false;
            int iterator = 0;
            while (!hasExist && iterator < originalSubjectsOfStudentList.Count)
            {
                if (subject.Id.Equals(originalSubjectsOfStudentList[iterator].Id))
                {
                    hasExist = true;
                }

                iterator++;
            }

            return hasExist;
        }

        private void RemoveSubjectToStudentButton_Click(object sender, RoutedEventArgs e)
        {
            subjectsOfStudentList.Remove(_subjectSelected);
            _studentSubjectXmlFile.Remove(_subjectSelected.Id, _studentId);
            SubjectAssignListBox.Items.Refresh();
            InfoSubjectLabel.Content = string.Empty;
            AddOrUpdateSubjectToStudentButton.Content = Utils.ADD;
        }
    }
}
