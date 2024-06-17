using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccounts
{
    public partial class Form1 : Form
    {
        List<Account> bankAccountsList = new List<Account>();
        public Form1()
        {
            InitializeComponent();
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            string id = idTextbox.Text;
            string name = nameTextbox.Text;

            if (decimal.TryParse(balanceTextbox.Text, out decimal balance))
            {

                //**************************
                Account newAccount = new Account(id, name, balance);
                bankAccountsList.Add(newAccount);
                accountListbox.Items.Add($"{name} - {id}");

            }
            else
                MessageBox.Show("金額格式錯誤");
            
            idTextbox.Text = "";
            nameTextbox.Text = "";
            balanceTextbox.Text = "";
        }

        private void accountListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = accountListbox.SelectedIndex;
            if (decimal.TryParse(amountTextBox.Text, out decimal amount))
            {
                processTransaction(index, amount);
            }
            else
                MessageBox.Show("金額格式錯誤");
        }

        private void processTransaction(int index, decimal amount)
        {

            //**************************
            Account selectedAccount = bankAccountsList[index];

            try
            {
                if (amount > 0)
                {
                    selectedAccount.Deposit(amount);
                }
                else if (amount < 0)
                {
                    selectedAccount.Withdraw(Math.Abs(amount));
                }
                else
                {
                    MessageBox.Show("交易金額必須大於零或小於零");
                }

                // 更新 ListBox 中顯示的帳戶資訊
                accountListbox.Items[index] = $"{selectedAccount.Name} - {selectedAccount.Id} ({selectedAccount.Balance:C})";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"提款失敗: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"提款失敗: {ex.Message}");
            }

        }
    }
}
