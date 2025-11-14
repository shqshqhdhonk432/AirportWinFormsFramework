using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AirportWinFormsFramework.Models;
using AirportWinFormsFramework.Services;

namespace AirportWinFormsFramework.Forms
{
    public partial class MainForm : Form
    {
        private readonly Airport _airport = new Airport();
        private ListSortDirection _lastSortDirection = ListSortDirection.Ascending;
        private string _lastSortProperty = nameof(Tariff.Destination);

        public MainForm()
        {
            InitializeComponent();

            gridTariffs.AutoGenerateColumns = false;
            gridTariffs.DataSource = _airport.Tariffs;

            gridTariffs.ColumnHeaderMouseClick += gridTariffs_ColumnHeaderMouseClick;

            lblStatus.Text = "Готово";
        }

        private void gridTariffs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = gridTariffs.Columns[e.ColumnIndex];
            var propName = column.DataPropertyName;
            if (string.IsNullOrWhiteSpace(propName)) return;

            if (_lastSortProperty == propName)
                _lastSortDirection = _lastSortDirection == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            else
            {
                _lastSortProperty = propName;
                _lastSortDirection = ListSortDirection.Ascending;
            }

            if (column.HeaderText.Contains("Итог"))
                _airport.SortBy("FinalPrice", _lastSortDirection);
            else
                _airport.SortBy(propName, _lastSortDirection);

            lblStatus.Text = "Сортировка: " + column.HeaderText + " (" + _lastSortDirection + ")";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new TariffForm()) // добавление
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        _airport.AddTariff(dlg.ResultTariff);
                        lblStatus.Text = "Добавлено.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedTariff();
            if (selected == null)
            {
                MessageBox.Show("Выберите строку.", "Подсказка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var originalDestination = selected.Destination;

            using (var dlg = new TariffForm(selected)) // редактирование (перегруженный конструктор)
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        _airport.UpdateTariff(originalDestination, dlg.ResultTariff);
                        lblStatus.Text = "Изменено.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedTariff();
            if (selected == null)
            {
                MessageBox.Show("Выберите строку.", "Подсказка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Удалить тариф '" + selected.Destination + "'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _airport.RemoveTariff(selected.Destination);
                lblStatus.Text = "Удалено.";
            }
        }

        private Tariff GetSelectedTariff()
        {
            if (gridTariffs.CurrentRow != null && gridTariffs.CurrentRow.DataBoundItem is Tariff t) return t;
            if (gridTariffs.SelectedRows.Count > 0 && gridTariffs.SelectedRows[0].DataBoundItem is Tariff t2) return t2;
            return null;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    var list = FileService.Load(openFileDialog1.FileName);

                    _airport.Tariffs.RaiseListChangedEvents = false;
                    _airport.Tariffs.Clear();
                    foreach (var t in list) _airport.Tariffs.Add(t);
                    _airport.Tariffs.RaiseListChangedEvents = true;
                    _airport.Tariffs.ResetBindings();

                    lblStatus.Text = "Загружено.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка чтения файла",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    FileService.Save(saveFileDialog1.FileName, _airport.Tariffs.ToList());
                    lblStatus.Text = "Сохранено.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка записи файла",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            try
            {
                var dest = _airport.FindMaxPriceDestination();
                MessageBox.Show("Максимальная итоговая цена у направления: " + dest,
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
