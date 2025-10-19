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
    public partial class Form2Authorization : Form
    {
        public Form2Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModelEF.ModelEF model = new ModelEF.ModelEF();
            if (model.UsersHash.ToList().Any(x =>
                x.Login == textBox1.Text &&
                x.Password == SHA256Builder.ConvertToHash(textBox2.Text)))
            {
                MessageBox.Show("Пользователь найден!");
                return;
            }
            MessageBox.Show("Пользователь не найден!");
        }
    }
}
