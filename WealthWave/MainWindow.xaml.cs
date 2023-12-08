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

namespace WealthWave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Account> accounts = new List<Account>(); // List to store accounts

        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         * Method:      btnDeposit_Click()
         * Description: This method handles the deposit button click and provides the user with the ability to deposit into their account. It also applies interest to their balance.
         * Parameters:  double newDepositAmount: The suggested amount to deposit.
         * Returns:     Void.
         */
        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtTransactionAmount.Text, out double depositAmount))
            {
                if (lvAccountInfo.SelectedItem is Account selectedAccount)
                {
                   // selectedAccount.DepositTransaction(depositAmount);
                    RefreshListView();
                }
            }
        }

        /*
         * Method:      btnWithdraw_Click()
         * Description: This method handles the withdraw button click and provides the user with the ability to withdraw from their account.
         * Parameters:  double newWithdrawAmount: The suggested amount to withdraw.
         * Returns:     Void.
         */
        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtTransactionAmount.Text, out double withdrawAmount))
            {
                if (lvAccountInfo.SelectedItem is Account selectedAccount)
                {
                    //selectedAccount.WithdrawTransaction(withdrawAmount);
                    RefreshListView();
                }
            }
        }

        /*
         * Method:      btnFindAccount_Click()
         * Description: This method handles the find account button click and allows users to search for an account by account number.
         * Parameters:  object sender: The sender of the event. RoutedEventArgs e: Event arguments.
         * Returns:     Void.
         */
        private void btnFindAccount_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtAccountNumber.Text, out int accountNumber))
            {
                Account foundAccount = accounts.Find(account => account.AccountNumber == accountNumber);
                if (foundAccount != null)
                {
                    lvAccountInfo.SelectedItem = foundAccount;
                }
            }
        }

        /*
         * Method:      RefreshListView()
         * Description: This method clears and refreshes the ListView with the current account data.
         * Parameters:  None.
         * Returns:     Void.
         */
        private void RefreshListView()
        {
            lvAccountInfo.Items.Clear();
            foreach (Account account in accounts)
            {
                lvAccountInfo.Items.Add(account);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create some sample accounts
            Account account1 = new SavingsAccount(1000);
            Account account2 = new ChequingAccount(1500);
            Account account3 = new LoanAccount(2000);

            // Add the accounts to the list
            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(account3);

            // Populate the ListView
            RefreshListView();
        }
    }
}
