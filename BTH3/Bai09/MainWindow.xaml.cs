using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;

namespace Bai09
{
    public partial class MainWindow : Window
    {
        private List<string> SubjectsLList = new List<string> { "Nhập môn lập trình", "Cấu trúc dữ liệu & Giải thuật", "Cơ sở dữ liệu", "Nhập môn Mạng máy tính", "Hệ điều hành", "Lập trình trực quan" };
        private Dictionary<string, Student> StudentDB = new Dictionary<string, Student>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeSubjects();
        }
        void InitializeSubjects()
        {
            foreach (string subject in SubjectsLList)
            {
                AvailableSubjects_ListBox.Items.Add(subject);
            }
        }
        private void AddSubjects_Button_Click(object sender, RoutedEventArgs e)
        {
            List<object> selectedSubjects = AvailableSubjects_ListBox.SelectedItems.Cast<object>().ToList();
            if (selectedSubjects.Count == 0)
            {
                return;
            }
            foreach (object subject in selectedSubjects)
            {
                SelectedSubjects_ListBox.Items.Add(subject);
                AvailableSubjects_ListBox.Items.Remove(subject);
            }
        }

        private void RemoveSubjects_Button_Click(object sender, RoutedEventArgs e)
        {
            List<object> selectedSubjects = SelectedSubjects_ListBox.SelectedItems.Cast<object>().ToList();
            if (selectedSubjects.Count == 0)
            {
                return;
            }
            foreach (object subject in selectedSubjects)
            {
                AvailableSubjects_ListBox.Items.Add(subject);
                SelectedSubjects_ListBox.Items.Remove(subject);
            }
        }
        private bool isAllInputFieldsValid()
        {
            if (string.IsNullOrWhiteSpace(StudentID_TextBox.Text) ||
                string.IsNullOrWhiteSpace(StudentName_TextBox.Text) ||
                StudentMajor_ComboBox.SelectedItem == null ||
                (Male_RadioButton.IsChecked == false && Female_RadioButton.IsChecked == false)
                )
            {
                return false;
            }
            return true;
        }
        private void ClearAllInputFields()
        {
            StudentID_TextBox.Clear();
            StudentName_TextBox.Clear();
            StudentMajor_ComboBox.SelectedItem = null;
            Male_RadioButton.IsChecked = false;
            Female_RadioButton.IsChecked = false;
        }
        private void Save_button_Click(object sender, RoutedEventArgs e)
        {
            if (!isAllInputFieldsValid())
            {
                MessageBox.Show("Vui lòng điều đầy đủ các thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string ID = StudentID_TextBox.Text;
            if (StudentDB.TryGetValue(ID, out Student existingStudent))
            {
                existingStudent.FullName = StudentName_TextBox.Text;
                existingStudent.Major = ((ComboBoxItem)StudentMajor_ComboBox.SelectedItem).Content.ToString();
                existingStudent.Gender = (Male_RadioButton.IsChecked == true ? "Nam" : "Nữ");
                existingStudent.RegisteredSubject.Clear();
                foreach (object s in SelectedSubjects_ListBox.Items)
                {
                    string subject = s as string;
                    existingStudent.RegisteredSubject.Add(subject);
                }
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                var newStudent = new Student
                {
                    ID = ID,
                    FullName = StudentName_TextBox.Text,
                    Major = ((ComboBoxItem)StudentMajor_ComboBox.SelectedItem).Content.ToString(),
                    Gender = (Male_RadioButton.IsChecked == true ? "Nam" : "Nữ")
                };
                foreach (object s in SelectedSubjects_ListBox.Items)
                {
                    string subject = s as string;
                    newStudent.RegisteredSubject.Add(subject);
                }
                StudentDB.Add(ID, newStudent);
                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            DisplayStudent();
            ClearAllInputFields();
            ResetSubjectMenu();
        }
        private void ResetSubjectMenu()
        {
            InitializeSubjects();
            SelectedSubjects_ListBox.Items.Clear();
        }
        private void DisplayStudent()
        {
            StudentInfos_ListView.Items.Clear();
            int STT = 0;
            foreach (var student in StudentDB.Values)
            {
                student.STT = ++STT;
                StudentInfos_ListView.Items.Add(student);
            }
        }
        private void RemoveSelections_button_Click(object sender, RoutedEventArgs e)
        {
            ResetSubjectMenu();
        }

        private void StudentInfos_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student selectedStudent = StudentInfos_ListView.SelectedItem as Student;
            if (selectedStudent == null)
            {
                ClearAllInputFields();
                ResetSubjectMenu();
                return;

            }
            StudentID_TextBox.Text = selectedStudent.ID;
            StudentName_TextBox.Text = selectedStudent.FullName;

            if (selectedStudent.Gender == "Nam")
            {
                Male_RadioButton.IsChecked = true;
            }
            else
            {
                Female_RadioButton.IsChecked = true;
            }
            foreach (ComboBoxItem item in StudentMajor_ComboBox.Items)
            {
                if (item.Content.ToString() == selectedStudent.Major)
                {
                    StudentMajor_ComboBox.SelectedItem = item;
                    break;
                }
            }
            AvailableSubjects_ListBox.Items.Clear();
            SelectedSubjects_ListBox.Items.Clear();
            foreach (string subject in SubjectsLList)
            {
                if (selectedStudent.RegisteredSubject.Contains(subject))
                {
                    SelectedSubjects_ListBox.Items.Add(subject);
                }
                else
                {
                    AvailableSubjects_ListBox.Items.Add(subject);
                }
            }
        }
    }
}