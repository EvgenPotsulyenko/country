using country.Models;

namespace country
{
    public partial class Form1 : Form
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var at = db.Areas.ToList();
            foreach (Area a in at)
            {
                if (a.Name == textBox8.Text)
                {
                    Country pt = new Country() { Name = textBox1.Text, square = Convert.ToInt32(textBox2.Text), AreasId = a.Id, population = Convert.ToInt32(textBox9.Text) };
                    db.�ountries.Add(pt);
                    db.SaveChanges();
                    MessageBox.Show("������ ���������");
                    break;
                }
                else
                {
                    MessageBox.Show("������� ��������");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                Area at = new Area() { Name = textBox3.Text };
                db.Areas.Add(at);
                db.SaveChanges();
                MessageBox.Show("������ ��������");
            }
            else
            {
                MessageBox.Show("������� ��������");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var at = db.�ountries.ToList();
            foreach (Country a in at)
            {
                if (a.Name == textBox7.Text)
                {
                    City pt = new City() { Name = textBox4.Text, capital = Convert.ToBoolean(textBox5.Text), population = Convert.ToInt32(textBox6.Text), CountryId = a.Id };
                    db.Cities.Add(pt);
                    db.SaveChanges();
                    MessageBox.Show("����� ��������");
                    break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = "true";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "false";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var ct = db.�ountries
                .OrderByDescending(c => c.population)
                .Take(3)
                .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var ct = db.Cities
               .Where(c => c.capital == true)
               .OrderByDescending(c => c.population)
               .Take(3)
               .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var ct = db.�ountries
               .OrderByDescending(c => c.population)
               .Take(1)
               .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var ct = db.Cities
               .Where(c => c.capital == true)
               .OrderByDescending(c => c.population)
               .Take(1)
               .ToList();
            foreach (var c1 in ct)
                MessageBox.Show($"{c1.Name}");
        }
    }
}