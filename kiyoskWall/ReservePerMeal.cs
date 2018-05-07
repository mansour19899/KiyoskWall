using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiyoskWall
{
    
    public partial class ReservePerMeal : Form
    {
        List<PerMeal> Meals;
        int Day;
        public ReservePerMeal(List<PerMeal> meal,int day)
        {
            InitializeComponent();
            Meals = meal;
            Day = day;

        }

        private void ReservePerMeal_Load(object sender, EventArgs e)
        {
            LoadMealDay();
        }

        private void LoadMealDay()
        {
            pic1.Image = Meals.ElementAt(Day).pictuer1;
            pic2.Image = Meals.ElementAt(Day).pictuer2;
            pic3.Image = Meals.ElementAt(Day).pictuer3;

            lbl1.Text = Meals.ElementAt(Day).Tray1.Name+"\n"+ Meals.ElementAt(Day).Tray1.Note;
            lbl2.Text = Meals.ElementAt(Day).Tray3.Name + "\n" + Meals.ElementAt(Day).Tray2.Note;
            lbl3.Text = Meals.ElementAt(Day).Tray3.Name + "\n" + Meals.ElementAt(Day).Tray3.Note;
        }
    }
}
