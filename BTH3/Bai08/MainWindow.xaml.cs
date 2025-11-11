using System.Security.Principal;
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

namespace Bai08
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, UserAccount> AccountDB = new Dictionary<string, UserAccount>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisplayAccountsAndTotal()
        {
            AccountListView.Items.Clear();
            decimal total = 0;
            int STT = 0;
            foreach(var account in AccountDB.Values)
            {
                account.STT = ++STT;
                AccountListView.Items.Add(account);
                total += account.Balance;
            }
            TotalAmount.Text = total.ToString();
        }
        private bool IsAllInputFieldsValid(out decimal balance)
        {
            balance = 0;
            if (string.IsNullOrWhiteSpace(AccountID_TextBox.Text)
               || string.IsNullOrWhiteSpace(CustomerName_TextBox.Text)
                || string.IsNullOrWhiteSpace(CustomerAddress_TextBox.Text)
                || !decimal.TryParse(AccountBalance_TextBox.Text, out balance))
            {
                return false;
            }
            return true;
        }
        private void AddUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAllInputFieldsValid(out decimal newBalance))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string ID = AccountID_TextBox.Text.Trim();

            if (AccountDB.TryGetValue(ID, out UserAccount existingAccount))
            {
                existingAccount.FullName = CustomerName_TextBox.Text;
                existingAccount.Address = CustomerAddress_TextBox.Text;
                existingAccount.Balance = newBalance;
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                var newAccount = new UserAccount
                {
                    ID = ID,
                    FullName = CustomerName_TextBox.Text,
                    Address = CustomerAddress_TextBox.Text,
                    Balance = newBalance
                };
                AccountDB.Add(ID ,newAccount);
                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            DisplayAccountsAndTotal();
            ClearInputFields();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string toDeleteAccountID = AccountID_TextBox.Text.Trim();

            if (AccountDB.TryGetValue(toDeleteAccountID, out UserAccount DeletingAccount))
            {
                MessageBoxResult result = MessageBox.Show($"Bạn có chắc muốn xoá tài khoản {toDeleteAccountID}, {DeletingAccount.FullName} không?", "Xác nhận",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    AccountDB.Remove(toDeleteAccountID);

                    DisplayAccountsAndTotal();
                    ClearInputFields();
                    MessageBox.Show("Xoá tài khoản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ClearInputFields()
        {
            AccountID_TextBox.Clear();
            CustomerName_TextBox.Clear();
            CustomerAddress_TextBox.Clear();
            AccountBalance_TextBox.Clear();
            AccountID_TextBox.Focus();
        }
        private void AccountListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserAccount selectedAccount = AccountListView.SelectedItem as UserAccount;
            if (selectedAccount != null)
            {
                AccountID_TextBox.Text = selectedAccount.ID;
                CustomerName_TextBox.Text = selectedAccount.FullName;
                CustomerAddress_TextBox.Text = selectedAccount.Address;
                AccountBalance_TextBox.Text = selectedAccount.Balance.ToString();
            }
        }
    }
}