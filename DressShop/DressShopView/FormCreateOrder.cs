using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.BusinessLogics;
using AbstractShopBusinessLogic.ViewModels;
using Unity;

namespace AbstractShopView
{
	public partial class FormCreateOrder : Form
	{
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly DressLogic _logicP;
        private readonly OrderLogic _logicO;
        public FormCreateOrder(DressLogic logicP, OrderLogic logicO)
        {
            InitializeComponent();
            _logicP = logicP;
            _logicO = logicO;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var list = _logicP.Read(null);
                if (list != null)
                {
                    comboBoxDress.DataSource = list;
                    comboBoxDress.DisplayMember = "DressName";
                    comboBoxDress.ValueMember = "Id";
                    comboBoxDress.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxDress.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxDress.SelectedValue);
                    DressViewModel dress = _logicP.Read(new DressBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * dress?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxDress_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDress.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    DressId = Convert.ToInt32(comboBoxDress.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
