using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Přístup_Heslo_Login
{
    public partial class Form1 : Form
    {
        string stringSalt = "UMEII4V1YteGw4CPqRwQqw==";
        string stringHash = "fGtDP1F/U6vpKCf5sugFZKK6z/TA3yE6bMVZZp7Q/6zUqcxK5KaUkstuAwqNi61LSu7lJ7Y06gb+TVzSvJfYsl2+iJEblwqgMBN9fm8+3YPqkULRLdzmu9cUEn5ze0hzOgXzpjw50FpDWo7Txcndr3NTvImM0TGlR2+Wt1/2D8PvS0kYUiJpZP9xdllJjQ6y0KKhufmTB10vpiNPrU20r2z09nGaJJ4zkJ5IrG8M43upN8CnAJO8Z7h2z1jFTyMsglS90PPuHbGIUiotqT5Hpn9Tic+IDS3Yo9LYVMFCqkOJa65PFefeM8ooDzUh142wFiVBju6WxjgD6NUUQ3k5";
        //byte[] savedSalt = { 3, 19, 154, 66, 205, 168, 184, 12 };
        //byte[] savedHash = { 53, 37, 225, 38, 242, 216, 255, 184 };

        byte[] salt = new byte[16];
        byte[] hash;
        public Form1()
        {
            InitializeComponent();
            var sůlGenerator = new RNGCryptoServiceProvider();
            sůlGenerator.GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes("1212", salt, 100000);
            hash = pbkdf2.GetBytes(255);

            //textBox1.Text = Convert.ToBase64String(salt);
            //textBox2.Text = Convert.ToBase64String(hash);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] hashFromSQL = Convert.FromBase64String(stringHash);
            string hashFromSQL = stringHash;
            byte[] saltFromSQL = Convert.FromBase64String(stringSalt);

            var pbkdf3 = new Rfc2898DeriveBytes(textBox2.Text, saltFromSQL, 100000);

            byte[] h = pbkdf3.GetBytes(255);

            if (Convert.ToBase64String(h) == hashFromSQL)
            {
                MessageBox.Show("Uživatel je přihlášen");
            }
        }
    }
}
