using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ModelEF;

namespace WindowsFormsApp1
{
    public partial class Form1AddUsers : Form
    {
        public Form1AddUsers()
        {
            InitializeComponent();
        }

        ModelEF.ModelEF model = new ModelEF.ModelEF();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1AddUsers_Load(object sender, EventArgs e)
        {
            StartLoad();
        }

        private void button1_Click(object sender, EventArgs e)//добавить
        {
            // Проверка на пустые поля
            if (textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            // Создаём объект класса и заносим в него данные
            UsersHash usersHash = new UsersHash();
            usersHash.Login = textBox1.Text;
            usersHash.Password = SHA256Builder.ConvertToHash(textBox2.Text);
            usersHash.FirstName = textBox3.Text;

            try
            {
                // Добавляем объект в список и сохраняем
                model.UsersHash.Add(usersHash);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                // Обновляем данные
                StartLoad();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Данные добавлены");
        }

        private void button2_Click(object sender, EventArgs e)//авторизоваться
        {
            // Открываем форму авторизации
            Form2Authorization form2 = new Form2Authorization();
            form2.ShowDialog();
        }
        void StartLoad()
        {
            dataGridView1.DataSource = model.UsersHash.ToList();
        }
    }
}
