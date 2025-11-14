using System;
using System.Windows.Forms;
using AirportWinFormsFramework.Models;

namespace AirportWinFormsFramework.Forms
{
    public partial class TariffForm : Form
    {
        // Здесь форма будет класть готовый объект тарифа,
        // который потом прочитает MainForm
        public Tariff ResultTariff { get; private set; }
        private void TariffForm_Load(object sender, EventArgs e)
        {
            // тоже ничего не делаем, обработчик просто существует
        }


        // Конструктор №1 — режим ДОБАВЛЕНИЯ
        public TariffForm()
        {
            InitializeComponent();          // создаёт все контролы с дизайнерской разметкой

            this.Text = "Добавить тариф";
            btnOk.Text = "Добавить";

            // значения по умолчанию
            rbStandard.Checked = true;
            numBasePrice.Value = 0;
            numDiscount.Value = 0;

            // изначально спрячем/отключим скидку
            ToggleDiscountControls(false);

            // при переключении радиокнопок показываем/прячем поле скидки
            rbStandard.CheckedChanged += (s, e) => ToggleDiscountControls(false);
            rbDiscount.CheckedChanged += (s, e) => ToggleDiscountControls(true);
        }

        // Конструктор №2 — режим РЕДАКТИРОВАНИЯ
        public TariffForm(Tariff existing)
        {
            InitializeComponent();

            this.Text = "Изменить тариф";
            btnOk.Text = "Сохранить";

            // заполняем поля текущими значениями
            txtDestination.Text = existing.Destination;
            numBasePrice.Value = (decimal)existing.BasePrice;

            if (existing.StrategyType == StrategyType.Standard)
            {
                rbStandard.Checked = true;
                ToggleDiscountControls(false);
            }
            else
            {
                rbDiscount.Checked = true;
                ToggleDiscountControls(true);
                numDiscount.Value = (decimal)existing.DiscountPercent;
            }

            rbStandard.CheckedChanged += (s, e) => ToggleDiscountControls(false);
            rbDiscount.CheckedChanged += (s, e) => ToggleDiscountControls(true);
        }

        // Показать/скрыть элементы скидки
        private void ToggleDiscountControls(bool visible)
        {
            numDiscount.Enabled = visible;
            numDiscount.Visible = visible;
            if (labelDiscount != null) labelDiscount.Visible = visible;
        }

        // Обработчик кнопки OK
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;   // если поля неверные — не закрываем форму

            string destination = txtDestination.Text.Trim();
            double basePrice = (double)numBasePrice.Value;

            StrategyType type;
            double discount = 0;

            if (rbStandard.Checked)
            {
                type = StrategyType.Standard;
            }
            else
            {
                type = StrategyType.Discount;
                discount = (double)numDiscount.Value;
            }

            try
            {
                // создаём объект Tariff с проверками из конструктора
                ResultTariff = new Tariff(destination, basePrice, type, discount);
                this.DialogResult = DialogResult.OK; // скажем вызывающей форме, что всё хорошо
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Простая валидация полей
        private bool ValidateInputs()
        {
            errorProvider1.Clear();
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtDestination.Text))
            {
                errorProvider1.SetError(txtDestination, "Укажите направление.");
                ok = false;
            }

            if (numBasePrice.Value < 0)
            {
                errorProvider1.SetError(numBasePrice, "Цена не может быть отрицательной.");
                ok = false;
            }

            if (rbDiscount.Checked)
            {
                if (numDiscount.Value < 0 || numDiscount.Value > 100)
                {
                    errorProvider1.SetError(numDiscount, "Скидка должна быть 0..100%.");
                    ok = false;
                }
            }

            return ok;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            // ничего не делаем, просто чтобы конструктор был доволен
        }


        // Обработчик кнопки Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // просто закрываем без результата
        }
    }
}
